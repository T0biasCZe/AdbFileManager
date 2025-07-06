namespace AdbFileManager {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
			SettingsManager.LoadSettings(); //nastaveni se musi naèist už tu aby jsme vìdìli zda je žádán dark mode
			if(SettingsManager.settings.DarkMode){
				DarkModeStartup.Initialize();
			}
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
			ApplicationConfiguration.Initialize();

			Application.Run(new Form1());
        }
    }
}