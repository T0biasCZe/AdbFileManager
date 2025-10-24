using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbFileManager {
	public class Settings {
		//Appearance
		public int ButtonTheme { get; set; } = 0; // 0 = Flat shaded, 1 = Flat, 2 = Fluent gradient
		public bool UseWindows11Icons { get; set; } = true; //true = W11 icons, false = W7 icons
		public bool DarkMode { get; set; } = false; //true = Dark mode, false = Light mode

		public bool ShowTwoProgressBars = true;

		public ushort? lang = null;
		public int progressWaitTimeMs = 60;


		//Behaviour
		public bool useLegacyCopy { get; set; } = false;
		public bool unwrapFilesLegacy { get; set; } = false;

	}
	public static class SettingsManager {
		public static Settings settings = new Settings();

		public static void SaveSettings() {
			string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string settingsPath = System.IO.Path.Combine(appDataPath, "tobiksoft", "AdbFileManager", "settings.xml");
			System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(settingsPath)); // Ensure the directory exists

			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Settings));
			using (var writer = new System.IO.StreamWriter(settingsPath)) {
				serializer.Serialize(writer, settings);
				writer.Flush();
				writer.Close();
			}
		}
		public static void LoadSettings() {
			//load the settings file if it exists, otherwise use default values
			string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string settingsPath = System.IO.Path.Combine(appDataPath, "tobiksoft", "AdbFileManager", "settings.xml");
			if (System.IO.File.Exists(settingsPath)) {
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Settings));
				using (var reader = new System.IO.StreamReader(settingsPath)) {
					settings = (Settings)serializer.Deserialize(reader);
					reader.Close();
				}
			} else {
				// If the settings file does not exist, use default values
				settings = new Settings();
			}

			ApplySettings();
		}

		public static void ApplySettings() {
			AdbProgressRunner.timeoutMs = settings.progressWaitTimeMs;
		}
	}
}
