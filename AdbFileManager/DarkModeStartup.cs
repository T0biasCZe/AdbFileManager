using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AdbFileManager {

	static class DarkModeStartup {
		private enum PreferredAppMode { Default = 0, AllowDark = 1, ForceDark = 2, ForceLight = 3 }

		[DllImport("uxtheme.dll", EntryPoint = "#135")]
		private static extern bool AllowDarkModeForApp(bool allow);

		[DllImport("uxtheme.dll", EntryPoint = "#137")]
		private static extern PreferredAppMode SetPreferredAppMode(PreferredAppMode mode);

		[DllImport("uxtheme.dll", EntryPoint = "#104")]
		private static extern void RefreshImmersiveColorPolicyState();

		[DllImport("dwmapi.dll")]
		private static extern int DwmSetWindowAttribute(
			IntPtr hwnd,
			int attr,
			ref int attrValue,
			int attrSize);

		private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20; // Win10 1809+ (19 on earlier insider builds)

		public static void Initialize() {
			// 1) Turn on dark-mode support for this process
			AllowDarkModeForApp(true);
			SetPreferredAppMode(PreferredAppMode.AllowDark);
			RefreshImmersiveColorPolicyState();
		}

		public static void ApplyToWindow(IntPtr hwnd) {
			// 2) Tell DWM to paint this window in immersive‐dark
			int dark = 1;
			DwmSetWindowAttribute(hwnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref dark, sizeof(int));
		}
	}

}
