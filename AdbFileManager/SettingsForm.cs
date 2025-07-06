using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdbFileManager {
	public partial class SettingsForm : Form {
		public SettingsForm() {
			InitializeComponent();
			//change the tab to the second tab
			tabControl1.SelectedTab = tab_appearance;

			// Load settings
			checkBox_darkMode.Checked = SettingsManager.settings.DarkMode;

			radioButton1.Checked = !SettingsManager.settings.UseWindows11Icons; // Windows Aero
			radioButton2.Checked = SettingsManager.settings.UseWindows11Icons; // Windows 11

			radioButton3.Checked = SettingsManager.settings.ButtonTheme == 0; // Flat shaded
			radioButton4.Checked = SettingsManager.settings.ButtonTheme == 1; // Flat
			radioButton5.Checked = SettingsManager.settings.ButtonTheme == 2; // Fluent gradient

			comboBox_lang.SelectedIndex = SettingsManager.settings.lang.HasValue ? SettingsManager.settings.lang.Value : 0; // Default to first language

			Application.DoEvents();
			loadingSettings = false;
		}

		bool loadingSettings = true;

		private void radioButton_iconStyle_CheckedChanged(object sender, EventArgs e) {
			if(loadingSettings) return;
			if(radioButton1.Checked) {
				SettingsManager.settings.UseWindows11Icons = false; // Windows Aero
			}
			else if(radioButton2.Checked) {
				SettingsManager.settings.UseWindows11Icons = true; // Windows 11
			}
			restartNeededChangesMade = true;
		}

		private void radioButton_buttonStyle_CheckedChanged(object sender, EventArgs e) {
			if(loadingSettings) return;
			if(radioButton3.Checked) {
				SettingsManager.settings.ButtonTheme = 0; // Flat shaded
			}
			else if(radioButton4.Checked) {
				SettingsManager.settings.ButtonTheme = 1; // Flat
			}
			else if(radioButton5.Checked) {
				SettingsManager.settings.ButtonTheme = 2; // Fluent gradient
			}
			restartNeededChangesMade = true;
		}

		private void checkBox_darkMode_CheckedChanged(object sender, EventArgs e) {
			if(loadingSettings) return;
			SettingsManager.settings.DarkMode = checkBox_darkMode.Checked;
			restartNeededChangesMade = true;
		}

		private void comboBox_lang_SelectedIndexChanged(object sender, EventArgs e) {
			if(loadingSettings) return;
			SettingsManager.settings.lang = (ushort)comboBox_lang.SelectedIndex;
			restartNeededChangesMade = true;
		}
		bool restartNeededChangesMade = false;
		private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(restartNeededChangesMade) {
				string message = AdbFileManager.strings.restartNeeded;
				MessageBox.Show(message, "Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
