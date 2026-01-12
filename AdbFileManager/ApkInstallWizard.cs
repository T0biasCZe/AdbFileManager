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
	public partial class ApkInstallWizard : Form {
		public ApkInstallWizard() {
			InitializeComponent();
			ApplySkin();
		}
		public ApkInstallWizard(string path) {
			InitializeComponent();
			ApplySkin();
			textBox_apkPath.Text = path;
		}

		void ApplySkin() {
			if(SettingsManager.settings.DarkMode) {
				this.BackColor = UIStyle.darkerBackColor;


				var controls = this.Controls.Cast<Control>();
				if(this.panel1 != null) controls = controls.Concat(this.panel1.Controls.Cast<Control>());

				foreach(Control c in controls) {
					if(c is Label || c is CheckBox || c is RadioButton) {
						c.ForeColor = Color.White;
						c.BackColor = Color.Transparent;
					}
				}
				textBox_apkPath.BackColor = UIStyle.backColor;
				textBox_apkPath.ForeColor = UIStyle.foreColor;
				textBox_customFlags.BackColor = UIStyle.backColor;
				textBox_customFlags.ForeColor = UIStyle.foreColor;
				richTextBox1.BackColor = UIStyle.backColor;

				button1.BackColor = UIStyle.brighterBackColor;
				button1.ForeColor = UIStyle.foreColor;

				textBox_apkPath.BorderStyle = BorderStyle.None;
				textBox_customFlags.BorderStyle = BorderStyle.None;
				richTextBox1.BorderStyle = BorderStyle.None;

				button1.FlatStyle = FlatStyle.Flat;

			}
			else if(!SettingsManager.settings.UseWindows11Icons) {
				this.BackColor = Color.FromArgb(185, 209, 234);
			}
		}

		private void UpdateGeneratedString() {
			StringBuilder sb = new StringBuilder();
			sb.Append("adb install ");
			if(checkBox_allPermissions.Checked) sb.Append("--grant-all-permissions ");
			if(checkBox_allowDowngrade.Checked) sb.Append("--downgrade ");
			if(checkBox_noStreaming.Checked) sb.Append("--no-streaming ");
			if(checkBox_tooOldBypass.Checked) sb.Append("--bypass-low-target-sdk-block ");
			if(checkBox_replace.Checked) sb.Append("--replace ");

			if(radioButton_destInternal.Checked) sb.Append("--install-location 1 ");
			if(radioButton_destSD.Checked) sb.Append("--install-location 2 ");

			sb.Append(textBox_customFlags.Text);
			sb.Append(" ");

			sb.Append(textBox_apkPath.Text);

			richTextBox1.Text = sb.ToString();
		}

		private void radioButton_dest_CheckedChanged(object sender, EventArgs e) {
			if(sender as RadioButton is RadioButton rb && rb.Checked) {
				UpdateGeneratedString();
			}
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e) {
			UpdateGeneratedString();
		}

		private void textBox_TextChanged(object sender, EventArgs e) {
			UpdateGeneratedString();
		}

		private void button1_Click(object sender, EventArgs e) {
			Form1.showConsole();
			Console.WriteLine("adb install command execution is running, please wait...");

			string result = Form1.adb(richTextBox1.Text);
			Console.WriteLine("adb install command execution finished.");
			MessageBox.Show(result, "Apk Install Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
			Form1.hideConsole();




		}
	}
}
