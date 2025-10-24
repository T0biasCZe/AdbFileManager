using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AdbFileManager {
	public static class AdbProgressRunner {
		private const string PipeName = "adb_progress_capture";

		private static bool _serverRunning = false;
		private static CancellationTokenSource? _cts;

		public static Func<int, Task>? OnProgressReceived;

		private static TaskCompletionSource<bool>? _serverReadyTcs;

		public static void StartPipeServer() {
			if(_serverRunning) return;

			_cts = new CancellationTokenSource();
			_serverRunning = true;
			_serverReadyTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

			Task.Run(async () =>
			{
				try {
					while(!_cts!.IsCancellationRequested) {
						using var server = new NamedPipeServerStream(
							PipeName, PipeDirection.In, 1,
							PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

						if(!_serverReadyTcs.Task.IsCompleted)
							_serverReadyTcs.TrySetResult(true);

						Log("[PipeServer] Waiting for hook to connect...");
						try {
							await server.WaitForConnectionAsync(_cts.Token);
						}
						catch(OperationCanceledException) {
							break;
						}
						catch(Exception ex) {
							Log("[PipeServer] WaitForConnectionAsync error: " + ex.Message);
							await Task.Delay(20);
							continue;
						}

						try {
							using var reader = new StreamReader(server, Encoding.UTF8);
							string? line = await reader.ReadLineAsync();
							if(!string.IsNullOrEmpty(line)) {
								Log("[Hook] " + line);
								int pct = ParseProgress(line);
								if(pct >= 0 && OnProgressReceived != null) {
									var _ = Task.Run(() => OnProgressReceived(pct));
								}
							}
						}
						catch(Exception ex) {
							Log("[PipeServer] Read error: " + ex.Message);
						}

						try { server.Disconnect(); } catch { }
						await Task.Delay(5);
					}
				}
				finally {
					Log("[PipeServer] Stopped.");
					_serverRunning = false;
					if(_serverReadyTcs != null && !_serverReadyTcs.Task.IsCompleted)
						_serverReadyTcs.TrySetResult(true);
				}
			});
		}
		public static Task ServerReady(Task? timeout = null) {
			if(_serverReadyTcs == null) return Task.CompletedTask;
			if(timeout == null) return _serverReadyTcs.Task;
			return Task.WhenAny(_serverReadyTcs.Task, timeout);
		}


		public static async Task StopPipeServer() {
			if(!_serverRunning) return;

			_cts?.Cancel();
			await Task.Delay(50);
		}

		public static int timeoutMs = 40;
		public static async Task RunAsync(string adbPath, string adbArgsString) {
			Log($"[Runner] Starting ADB. Path='{adbPath}' Args='{adbArgsString}'");

			if(string.IsNullOrWhiteSpace(adbPath)) throw new ArgumentException("adbPath is required", nameof(adbPath));
			if(!System.IO.File.Exists(adbPath)) throw new FileNotFoundException("adb not found", adbPath);

			adbArgsString ??= string.Empty;

			string dllPath = Path.Combine(AppContext.BaseDirectory, "HookDll.dll");
			if(!System.IO.File.Exists(dllPath)) throw new FileNotFoundException("Hook DLL not found", dllPath);
			if(!_serverRunning) {
				Log("[Runner] Pipe server not running — starting it automatically.");
				StartPipeServer();
			}

			try {
				var timeoutTask = Task.Delay(timeoutMs);
				await ServerReady(timeoutTask);
				if(!_serverReadyTcs!.Task.IsCompleted)
					Log("[Runner] ServerReady timed out after 100ms (continuing anyway).");
			}
			catch(Exception ex) {
				Log("[Runner] ServerReady wait exception: " + ex.Message);
			}

			var adbProcess = Injector.InjectAndGetProcess(adbPath, dllPath, adbArgsString);
			if(adbProcess == null) throw new InvalidOperationException("Failed to start + inject adb process");

			Log($"[Runner] adb process started (PID={adbProcess.Id})");
			await Task.Run(() => adbProcess.WaitForExit());
			Log("[Runner] adb operation finished.");
		}



		//"[ 42%] filename"
		private static int ParseProgress(string line) {
			if(string.IsNullOrEmpty(line)) return -1;
			int start = line.IndexOf('[');
			int end = line.IndexOf('%');
			if(start >= 0 && end > start) {
				string number = line.Substring(start + 1, end - start - 1).Trim();
				if(int.TryParse(number, out int pct)) return pct;
			}
			return -1;
		}

		private static void Log(string msg) {
			Console.WriteLine($"[DBG] {DateTime.Now:HH:mm:ss.fff} [Runner] {msg}");
		}


		// --------------------- Injector ---------------------
		public static class Injector {
			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
			struct STARTUPINFO {
				public int cb; public IntPtr lpReserved; public IntPtr lpDesktop; public IntPtr lpTitle;
				public int dwX; public int dwY; public int dwXSize; public int dwYSize;
				public int dwXCountChars; public int dwYCountChars; public int dwFillAttribute;
				public int dwFlags; public short wShowWindow; public short cbReserved2;
				public IntPtr lpReserved2; public IntPtr hStdInput; public IntPtr hStdOutput; public IntPtr hStdError;
			}

			[StructLayout(LayoutKind.Sequential)]
			struct PROCESS_INFORMATION {
				public IntPtr hProcess; public IntPtr hThread; public uint dwProcessId; public uint dwThreadId;
			}

			const uint CREATE_SUSPENDED = 0x00000004;
			const uint MEM_COMMIT = 0x1000;
			const uint PAGE_READWRITE = 0x04;

			[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
			static extern bool CreateProcessW(
				string lpApplicationName, string lpCommandLine,
				IntPtr lpProcessAttributes, IntPtr lpThreadAttributes,
				bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment,
				string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo,
				out PROCESS_INFORMATION lpProcessInformation);

			[DllImport("kernel32.dll", SetLastError = true)]
			static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flAllocationType, uint flProtect);

			[DllImport("kernel32.dll", SetLastError = true)]
			static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, UIntPtr size, out UIntPtr lpNumberOfBytesWritten);

			[DllImport("kernel32.dll")]
			static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

			[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
			static extern IntPtr GetModuleHandle(string lpModuleName);

			[DllImport("kernel32.dll", SetLastError = true)]
			static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, UIntPtr dwStackSize,
				IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

			[DllImport("kernel32.dll")]
			static extern uint ResumeThread(IntPtr hThread);

			private static string QuoteArg(string arg) {
				if(string.IsNullOrEmpty(arg)) return "\"\"";
				bool needsQuotes = arg.Contains(" ") || arg.Contains("\t") || arg.Contains("\"");
				if(!needsQuotes) return arg;

				var sb = new StringBuilder();
				sb.Append('"');
				int backslashes = 0;
				foreach(char c in arg) {
					if(c == '\\') backslashes++;
					else if(c == '"') {
						sb.Append('\\', backslashes * 2 + 1);
						sb.Append('"');
						backslashes = 0;
					}
					else {
						if(backslashes > 0) { sb.Append('\\', backslashes); backslashes = 0; }
						sb.Append(c);
					}
				}
				if(backslashes > 0) sb.Append('\\', backslashes * 2);
				sb.Append('"');
				return sb.ToString();
			}

			private static string BuildCommandLine(string exePath, string[] args) {
				var sb = new StringBuilder();
				sb.Append(QuoteArg(exePath));
				if(args != null) {
					foreach(var a in args) {
						sb.Append(' ');
						//sb.Append(QuoteArg(a)); //remove QuoteArg
						sb.Append(a);
					}
				}
				return sb.ToString();
			}

			public static Process? InjectAndGetProcess(string adbPath, string dllFullPath, string adbArgsString) {
				string[] args = string.IsNullOrWhiteSpace(adbArgsString) ? null : new[] { adbArgsString };

				STARTUPINFO si = new STARTUPINFO();
				si.cb = Marshal.SizeOf(si);
				PROCESS_INFORMATION pi;

				Log("adbpath: " + adbPath + " args: " + adbArgsString);

				string cmdLine = BuildCommandLine(adbPath, args);

				Log("cmdline: " + cmdLine);

				bool created = CreateProcessW(null, cmdLine, IntPtr.Zero, IntPtr.Zero, false,
					CREATE_SUSPENDED, IntPtr.Zero, Path.GetDirectoryName(adbPath), ref si, out pi);

				if(!created) { Log("[Injector] CreateProcess failed: " + Marshal.GetLastWin32Error()); return null; }

				IntPtr proc = pi.hProcess;
				byte[] dllBytes = Encoding.Unicode.GetBytes(dllFullPath + "\0");
				IntPtr remoteMem = VirtualAllocEx(proc, IntPtr.Zero, (UIntPtr)dllBytes.Length, MEM_COMMIT, PAGE_READWRITE);
				if(remoteMem == IntPtr.Zero) { Log("[Injector] VirtualAllocEx failed: " + Marshal.GetLastWin32Error()); return null; }

				if(!WriteProcessMemory(proc, remoteMem, dllBytes, (UIntPtr)dllBytes.Length, out _)) { Log("[Injector] WriteProcessMemory failed: " + Marshal.GetLastWin32Error()); return null; }

				IntPtr hKernel = GetModuleHandle("kernel32.dll");
				IntPtr loadLibAddr = GetProcAddress(hKernel, "LoadLibraryW");
				if(loadLibAddr == IntPtr.Zero) { Log("[Injector] GetProcAddress(LoadLibraryW) failed."); return null; }

				IntPtr hThread = CreateRemoteThread(proc, IntPtr.Zero, UIntPtr.Zero, loadLibAddr, remoteMem, 0, IntPtr.Zero);
				if(hThread == IntPtr.Zero) { Log("[Injector] CreateRemoteThread failed: " + Marshal.GetLastWin32Error()); return null; }

				ResumeThread(pi.hThread);
				Log("[Injector] Injection complete. PID=" + pi.dwProcessId);

				try { return Process.GetProcessById((int)pi.dwProcessId); }
				catch { return null; }
			}
		}
	}
}
