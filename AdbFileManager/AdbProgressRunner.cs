using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace AdbFileManager {
	/// <summary>
	/// Runs ADB commands with progress reporting using Windows ConPTY for terminal emulation.
	/// </summary>
	public static class AdbProgressRunner {
		/// <summary>
		/// Callback invoked when progress percentage is received from ADB.
		/// </summary>
		public static Func<int, Task>? OnProgressReceived;

		private static int _currentProcessId;
		private static string? _adbPath;
		private static bool _isCancelled;
		private static readonly object _lock = new();
		private static readonly Regex ProgressRegex = new(@"\[\s*(\d+)%\]", RegexOptions.Compiled);

		/// <summary>
		/// Gets whether the current operation has been cancelled.
		/// Check this in file loops to stop processing remaining files.
		/// </summary>
		public static bool IsCancelled {
			get { lock (_lock) { return _isCancelled; } }
		}

		/// <summary>
		/// Resets the cancellation flag. Call before starting a new batch of files.
		/// </summary>
		public static void ResetCancellation() {
			lock (_lock) {
				_isCancelled = false;
			}
		}

		/// <summary>
		/// Cancels the currently running ADB process and restarts the ADB server.
		/// </summary>
		public static void Cancel() {
			int pid;
			string? adbPath;
			lock (_lock) {
				_isCancelled = true;
				pid = _currentProcessId;
				adbPath = _adbPath;
				_currentProcessId = 0;
			}

			if (pid <= 0) return;

			// Kill process tree using taskkill (most reliable on Windows)
			try {
				using var taskkill = Process.Start(new ProcessStartInfo {
					FileName = "taskkill",
					Arguments = $"/F /T /PID {pid}",
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				});
				taskkill?.WaitForExit(5000);
			}
			catch {
				// Fallback to Process.Kill
				try {
					using var process = Process.GetProcessById(pid);
					if (!process.HasExited) {
						process.Kill(entireProcessTree: true);
					}
				}
				catch { }
			}

			// Restart ADB server to clean up device connection
			if (!string.IsNullOrEmpty(adbPath) && System.IO.File.Exists(adbPath)) {
				RestartAdbServer(adbPath);
			}
		}

		/// <summary>
		/// Runs an ADB command asynchronously with progress reporting.
		/// </summary>
		public static async Task RunAsync(string adbPath, string adbArgsString) {
			if (string.IsNullOrWhiteSpace(adbPath))
				throw new ArgumentException("adbPath is required", nameof(adbPath));
			if (!System.IO.File.Exists(adbPath))
				throw new FileNotFoundException("ADB executable not found", adbPath);

			lock (_lock) {
				_adbPath = adbPath;
			}

			if (IsConPtySupported()) {
				await RunWithConPtyAsync(adbPath, adbArgsString ?? string.Empty);
			}
			else {
				await RunWithProcessAsync(adbPath, adbArgsString ?? string.Empty);
			}
		}

		private static bool IsConPtySupported() {
			if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return false;
			var version = Environment.OSVersion.Version;
			return version.Major > 10 || (version.Major == 10 && version.Build >= 17763);
		}

		private static void RestartAdbServer(string adbPath) {
			try {
				using var kill = Process.Start(new ProcessStartInfo {
					FileName = adbPath,
					Arguments = "kill-server",
					UseShellExecute = false,
					CreateNoWindow = true
				});
				kill?.WaitForExit(3000);

				using var start = Process.Start(new ProcessStartInfo {
					FileName = adbPath,
					Arguments = "start-server",
					UseShellExecute = false,
					CreateNoWindow = true
				});
				start?.WaitForExit(3000);
			}
			catch { }
		}

		private static async Task RunWithConPtyAsync(string adbPath, string args) {
			IntPtr inputReadSide = IntPtr.Zero, inputWriteSide = IntPtr.Zero;
			IntPtr outputReadSide = IntPtr.Zero, outputWriteSide = IntPtr.Zero;
			IntPtr hPC = IntPtr.Zero;
			IntPtr hProcess = IntPtr.Zero;

			try {
				// Create pipes
				var sa = new SECURITY_ATTRIBUTES { bInheritHandle = true };
				sa.nLength = Marshal.SizeOf(sa);

				if (!CreatePipe(out inputReadSide, out inputWriteSide, ref sa, 0))
					throw new InvalidOperationException("Failed to create input pipe");
				if (!CreatePipe(out outputReadSide, out outputWriteSide, ref sa, 0))
					throw new InvalidOperationException("Failed to create output pipe");

				// Create pseudo console
				var size = new COORD { X = 120, Y = 30 };
				int hr = CreatePseudoConsole(size, inputReadSide, outputWriteSide, 0, out hPC);
				if (hr != 0)
					throw new InvalidOperationException($"CreatePseudoConsole failed: 0x{hr:X8}");

				// Prepare startup info with pseudo console attribute
				var siEx = new STARTUPINFOEX();
				siEx.StartupInfo.cb = Marshal.SizeOf<STARTUPINFOEX>();

				IntPtr lpSize = IntPtr.Zero;
				InitializeProcThreadAttributeList(IntPtr.Zero, 1, 0, ref lpSize);
				siEx.lpAttributeList = Marshal.AllocHGlobal(lpSize);

				if (!InitializeProcThreadAttributeList(siEx.lpAttributeList, 1, 0, ref lpSize))
					throw new InvalidOperationException("InitializeProcThreadAttributeList failed");

				if (!UpdateProcThreadAttribute(siEx.lpAttributeList, 0, (IntPtr)PROC_THREAD_ATTRIBUTE_PSEUDOCONSOLE,
					hPC, (IntPtr)IntPtr.Size, IntPtr.Zero, IntPtr.Zero))
					throw new InvalidOperationException("UpdateProcThreadAttribute failed");

				// Create process
				var pi = new PROCESS_INFORMATION();
				bool success = CreateProcess(
					null, $"\"{adbPath}\" {args}",
					IntPtr.Zero, IntPtr.Zero, false,
					EXTENDED_STARTUPINFO_PRESENT,
					IntPtr.Zero, Path.GetDirectoryName(adbPath),
					ref siEx, out pi);

				if (!success)
					throw new InvalidOperationException($"CreateProcess failed: {Marshal.GetLastWin32Error()}");

				hProcess = pi.hProcess;
				CloseHandle(pi.hThread);
				CloseHandle(inputReadSide);
				CloseHandle(outputWriteSide);
				inputReadSide = IntPtr.Zero;
				outputWriteSide = IntPtr.Zero;

				lock (_lock) {
					_currentProcessId = (int)pi.dwProcessId;
				}

				// Read output from pseudo console
				var outputHandle = outputReadSide;
				outputReadSide = IntPtr.Zero;

				var readTask = Task.Run(() => ReadProgressOutput(outputHandle));

				using var process = Process.GetProcessById((int)pi.dwProcessId);
				await process.WaitForExitAsync();

				lock (_lock) {
					_currentProcessId = 0;
				}

				// Close pseudo console to signal EOF
				if (hPC != IntPtr.Zero) {
					ClosePseudoConsole(hPC);
					hPC = IntPtr.Zero;
				}

				await Task.WhenAny(readTask, Task.Delay(3000));
			}
			finally {
				lock (_lock) {
					_currentProcessId = 0;
				}
				if (inputReadSide != IntPtr.Zero) CloseHandle(inputReadSide);
				if (inputWriteSide != IntPtr.Zero) CloseHandle(inputWriteSide);
				if (outputReadSide != IntPtr.Zero) CloseHandle(outputReadSide);
				if (outputWriteSide != IntPtr.Zero) CloseHandle(outputWriteSide);
				if (hPC != IntPtr.Zero) ClosePseudoConsole(hPC);
				if (hProcess != IntPtr.Zero) CloseHandle(hProcess);
			}
		}

		private static void ReadProgressOutput(IntPtr outputHandle) {
			var buffer = new byte[1024];
			int lastProgress = -1;

			using var safeHandle = new SafeFileHandle(outputHandle, true);
			using var stream = new FileStream(safeHandle, FileAccess.Read);

			try {
				int bytesRead;
				while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {
					string text = Encoding.UTF8.GetString(buffer, 0, bytesRead);
					foreach (Match match in ProgressRegex.Matches(text)) {
						if (int.TryParse(match.Groups[1].Value, out int pct) &&
							pct >= 0 && pct <= 100 && pct != lastProgress) {
							lastProgress = pct;
							OnProgressReceived?.Invoke(pct);
						}
					}
				}
			}
			catch { }
		}

		private static async Task RunWithProcessAsync(string adbPath, string args) {
			var psi = new ProcessStartInfo {
				FileName = adbPath,
				Arguments = args,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true,
				WorkingDirectory = Path.GetDirectoryName(adbPath) ?? AppContext.BaseDirectory
			};

			using var process = new Process { StartInfo = psi };
			process.Start();

			lock (_lock) {
				_currentProcessId = process.Id;
			}

			int lastProgress = -1;
			var stderrTask = Task.Run(async () => {
				var buffer = new StringBuilder();
				var stream = process.StandardError.BaseStream;
				var byteBuffer = new byte[1];

				while (true) {
					int bytesRead = await stream.ReadAsync(byteBuffer, 0, 1);
					if (bytesRead == 0) break;

					char c = (char)byteBuffer[0];
					if (c == '\r' || c == '\n') {
						if (buffer.Length > 0) {
							var match = ProgressRegex.Match(buffer.ToString());
							if (match.Success && int.TryParse(match.Groups[1].Value, out int pct) &&
								pct >= 0 && pct <= 100 && pct != lastProgress) {
								lastProgress = pct;
								OnProgressReceived?.Invoke(pct);
							}
							buffer.Clear();
						}
					}
					else {
						buffer.Append(c);
					}
				}
			});

			await Task.WhenAll(stderrTask, process.StandardOutput.ReadToEndAsync());
			await process.WaitForExitAsync();

			lock (_lock) {
				_currentProcessId = 0;
			}
		}

		#region Native Methods

		private const int PROC_THREAD_ATTRIBUTE_PSEUDOCONSOLE = 0x00020016;
		private const uint EXTENDED_STARTUPINFO_PRESENT = 0x00080000;

		[StructLayout(LayoutKind.Sequential)]
		private struct COORD {
			public short X;
			public short Y;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct SECURITY_ATTRIBUTES {
			public int nLength;
			public IntPtr lpSecurityDescriptor;
			[MarshalAs(UnmanagedType.Bool)]
			public bool bInheritHandle;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct STARTUPINFO {
			public int cb;
			public string lpReserved;
			public string lpDesktop;
			public string lpTitle;
			public int dwX, dwY, dwXSize, dwYSize;
			public int dwXCountChars, dwYCountChars, dwFillAttribute, dwFlags;
			public short wShowWindow, cbReserved2;
			public IntPtr lpReserved2, hStdInput, hStdOutput, hStdError;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct STARTUPINFOEX {
			public STARTUPINFO StartupInfo;
			public IntPtr lpAttributeList;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct PROCESS_INFORMATION {
			public IntPtr hProcess, hThread;
			public uint dwProcessId, dwThreadId;
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool CreatePipe(out IntPtr hReadPipe, out IntPtr hWritePipe,
			ref SECURITY_ATTRIBUTES lpPipeAttributes, uint nSize);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CreatePseudoConsole(COORD size, IntPtr hInput, IntPtr hOutput,
			uint dwFlags, out IntPtr phPC);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern void ClosePseudoConsole(IntPtr hPC);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool InitializeProcThreadAttributeList(IntPtr lpAttributeList,
			int dwAttributeCount, int dwFlags, ref IntPtr lpSize);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool UpdateProcThreadAttribute(IntPtr lpAttributeList, uint dwFlags,
			IntPtr Attribute, IntPtr lpValue, IntPtr cbSize, IntPtr lpPreviousValue, IntPtr lpReturnSize);

		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "CreateProcessW")]
		private static extern bool CreateProcess(string? lpApplicationName, string lpCommandLine,
			IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles,
			uint dwCreationFlags, IntPtr lpEnvironment, string? lpCurrentDirectory,
			ref STARTUPINFOEX lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool CloseHandle(IntPtr hObject);

		#endregion
	}
}
