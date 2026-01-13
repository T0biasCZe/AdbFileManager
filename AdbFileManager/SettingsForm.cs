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

            checkBox_showTwoProgressBars.Checked = SettingsManager.settings.ShowTwoProgressBars;

            radioButton1.Checked = !SettingsManager.settings.UseWindows11Icons; // Windows Aero
            radioButton2.Checked = SettingsManager.settings.UseWindows11Icons; // Windows 11

            radioButton3.Checked = SettingsManager.settings.ButtonTheme == 0; // Flat shaded
            radioButton4.Checked = SettingsManager.settings.ButtonTheme == 1; // Flat
            radioButton5.Checked = SettingsManager.settings.ButtonTheme == 2; // Fluent gradient

            trackBar_progressWait.Value = (SettingsManager.settings.progressWaitTimeMs - 20) / 10;
            label_trackbarValue.Left = (trackBar_progressWait.Left + trackBar_progressWait.Value * (trackBar_progressWait.Width - 20) / trackBar_progressWait.Maximum) - 8;

            comboBox_lang.SelectedIndex = SettingsManager.settings.lang.HasValue ? SettingsManager.settings.lang.Value : 0; // Default to first language

            checkBox_useLegacyCopy.Checked = SettingsManager.settings.useLegacyCopy;
            checkBox_unwrapFolderLegacy.Checked = SettingsManager.settings.unwrapFilesLegacy;

            checkBox3.Checked = SettingsManager.settings.ShowAndroidBackButton;

            checkBox_compatibilityMode.Checked = SettingsManager.settings.useCompatibilityMode;
            checkBox_fastCompatibility.Checked = SettingsManager.settings.useFastCompatibility;
            checkBox_previewMediaFiles.Checked = SettingsManager.settings.previewMediaFiles;
            checkBox_keepFileModificationDate.Checked = SettingsManager.settings.keepFileModificationDate;
            checkBox_rememberLocation.Checked = SettingsManager.settings.rememberDirectory;

            Application.DoEvents();

            ApplyLocalization();
            loadingSettings = false;
        }

        bool loadingSettings = true;

        private void radioButton_iconStyle_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            if (radioButton1.Checked) {
                SettingsManager.settings.UseWindows11Icons = false; // Windows Aero
            }
            else if (radioButton2.Checked) {
                SettingsManager.settings.UseWindows11Icons = true; // Windows 11
            }
            restartNeededChangesMade = true;
        }

        private void radioButton_buttonStyle_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            if (radioButton3.Checked) {
                SettingsManager.settings.ButtonTheme = 0; // Flat shaded
            }
            else if (radioButton4.Checked) {
                SettingsManager.settings.ButtonTheme = 1; // Flat
            }
            else if (radioButton5.Checked) {
                SettingsManager.settings.ButtonTheme = 2; // Fluent gradient
            }
            restartNeededChangesMade = true;
        }

        private void checkBox_darkMode_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.DarkMode = checkBox_darkMode.Checked;
            restartNeededChangesMade = true;
        }

        private void comboBox_lang_SelectedIndexChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.lang = (ushort)comboBox_lang.SelectedIndex;
            restartNeededChangesMade = true;
        }
        bool restartNeededChangesMade = false;
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (restartNeededChangesMade) {
                string message = AdbFileManager.strings.restartNeeded;
                MessageBox.Show(message, AdbFileManager.strings.restartRequired, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox_useLegacyCopy_CheckedChanged(object sender, EventArgs e) {
            checkBox_unwrapFolderLegacy.Enabled = checkBox_useLegacyCopy.Checked;
            if (loadingSettings) return;
            SettingsManager.settings.useLegacyCopy = checkBox_useLegacyCopy.Checked;

        }

        private void checkBox_unwrapFolderLegacy_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.unwrapFilesLegacy = checkBox_unwrapFolderLegacy.Checked;
        }

        private void checkBox_showTwoProgressBars_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.ShowTwoProgressBars = checkBox_showTwoProgressBars.Checked;
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void trackBar_progressWait_Scroll(object sender, EventArgs e) {
            Console.WriteLine("trackBar_progressWait_Scroll fired");
            //move label_trackbarValue according to trackbar position
            label_trackbarValue.Left = (trackBar_progressWait.Left + trackBar_progressWait.Value * (trackBar_progressWait.Width - 20) / trackBar_progressWait.Maximum) - 8;

            int value = trackBar_progressWait.Value * 10 + 20;

            label_trackbarValue.Text = value.ToString() + " ms";

            AdbProgressRunner.timeoutMs = value;

            if (loadingSettings) return;

            SettingsManager.settings.progressWaitTimeMs = value;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.ShowAndroidBackButton = checkBox3.Checked;
        }

        private void ApplyLocalization() {
            this.Text = AdbFileManager.strings.settings_title;

            // Tabs
            //tab_behaviour.Text = AdbFileManager.strings.settings_tab_behaviour; //crashes for some reason
            tab_appearance.Text = AdbFileManager.strings.settings_tab_appearance;

            // Behaviour tab
            label_language.Text = AdbFileManager.strings.settings_language;
            checkBox_keepFileModificationDate.Text = AdbFileManager.strings.settings_keepFileDate;
            checkBox_previewMediaFiles.Text = AdbFileManager.strings.settings_previewMedia;
            checkBox_useLegacyCopy.Text = AdbFileManager.strings.settings_useLegacyCopy;
            checkBox_unwrapFolderLegacy.Text = AdbFileManager.strings.settings_unwrapFolders;
            label5.Text = AdbFileManager.strings.settings_progressSyncDelay;
            checkBox_compatibilityMode.Text = AdbFileManager.strings.settings_compatibilityFix;
            checkBox_fastCompatibility.Text = AdbFileManager.strings.settings_fastCompatibility;
            checkBox_rememberLocation.Text = AdbFileManager.strings.settings_openLastLocation;

            // Appearance tab
            label1.Text = AdbFileManager.strings.settings_iconStyle;
            radioButton1.Text = AdbFileManager.strings.settings_windowsAero;
            radioButton2.Text = AdbFileManager.strings.settings_windows11;
            label2.Text = AdbFileManager.strings.settings_buttonDesign;
            radioButton3.Text = AdbFileManager.strings.settings_flatShaded;
            radioButton4.Text = AdbFileManager.strings.settings_flat;
            radioButton5.Text = AdbFileManager.strings.settings_fluentGradient;
            checkBox_darkMode.Text = AdbFileManager.strings.settings_darkMode;
            label4.Text = AdbFileManager.strings.settings_darkModeNote;
            checkBox_showTwoProgressBars.Text = AdbFileManager.strings.settings_twoProgressBars;
            checkBox3.Text = AdbFileManager.strings.settings_showBackButton;
        }

        private void checkBox_compatibilityMode_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.useCompatibilityMode = checkBox_compatibilityMode.Checked;
        }
        private void checkBox_fastCompatibility_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.useFastCompatibility = checkBox_fastCompatibility.Checked;
        }

        private void checkBox_previewMediaFiles_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.previewMediaFiles = checkBox_previewMediaFiles.Checked;
        }

        private void checkBox_keepFileModificationDate_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.keepFileModificationDate = checkBox_keepFileModificationDate.Checked;
        }

        private void checkBox_rememberLocation_CheckedChanged(object sender, EventArgs e) {
            if (loadingSettings) return;
            SettingsManager.settings.rememberDirectory = checkBox_rememberLocation.Checked;
        }
    }
}
