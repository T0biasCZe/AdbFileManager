using Microsoft.WindowsAPICodePack.Controls.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdbFileManager {
	public enum DWMWINDOWATTRIBUTE : uint {
		DWMWA_NCRENDERING_ENABLED,
		DWMWA_NCRENDERING_POLICY,
		DWMWA_TRANSITIONS_FORCEDISABLED,
		DWMWA_ALLOW_NCPAINT,
		DWMWA_CAPTION_BUTTON_BOUNDS,
		DWMWA_NONCLIENT_RTL_LAYOUT,
		DWMWA_FORCE_ICONIC_REPRESENTATION,
		DWMWA_FLIP3D_POLICY,
		DWMWA_EXTENDED_FRAME_BOUNDS,
		DWMWA_HAS_ICONIC_BITMAP,
		DWMWA_DISALLOW_PEEK,
		DWMWA_EXCLUDED_FROM_PEEK,
		DWMWA_CLOAK,
		DWMWA_CLOAKED,
		DWMWA_FREEZE_REPRESENTATION,
		DWMWA_PASSIVE_UPDATE_MODE,
		DWMWA_USE_HOSTBACKDROPBRUSH,
		DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19,
		DWMWA_USE_IMMERSIVE_DARK_MODE,
		DWMWA_WINDOW_CORNER_PREFERENCE = 33,
		DWMWA_BORDER_COLOR,
		DWMWA_CAPTION_COLOR,
		DWMWA_TEXT_COLOR,
		DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
		DWMWA_SYSTEMBACKDROP_TYPE,
		DWMWA_LAST
	}

	public static class DarkModeHelper {

		[DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd,
													   DWMWINDOWATTRIBUTE attribute,
													   ref int pvAttribute,
													   uint cbAttribute);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
		private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

		public static void ApplyDark(bool enable, nint handle) {
			var preference = Convert.ToInt32(true);
			if(DwmSetWindowAttribute(handle, DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, ref preference, sizeof(uint)) != 0) {
				Marshal.ThrowExceptionForHR(DwmSetWindowAttribute(handle, DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, ref preference, sizeof(uint)));
			}
		}

		public static IntPtr GetExplorerBrowserHandle(IntPtr parentHandle) {
			IntPtr shellViewHandle = IntPtr.Zero;

			// Enumerate all child windows to find the ShellView window
			EnumChildWindows(parentHandle, (hWnd, lParam) =>
			{
				StringBuilder className = new StringBuilder(256);
				GetClassName(hWnd, className, className.Capacity);
				if(className.ToString() == "ShellView") {
					shellViewHandle = hWnd;
					return false; // Stop enumeration
				}
				return true; // Continue enumeration
			}, IntPtr.Zero);

			return shellViewHandle;
		}

	}
}
