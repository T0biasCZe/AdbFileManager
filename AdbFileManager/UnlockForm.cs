using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Net.Mime.MediaTypeNames;

namespace AdbFileManager {
	public partial class UnlockForm : Form {
		public UnlockForm() {
			InitializeComponent();
			ApplyLocalization();
		}

		private void ApplyLocalization() {
			this.Text = AdbFileManager.strings.unlock_title;
			textBox1.PlaceholderText = AdbFileManager.strings.unlock_passwordPlaceholder;
			richTextBox1.Text = AdbFileManager.strings.unlock_description;
		}

		private void UnlockForm_Load(object sender, EventArgs e) {
			DeviceList();
		}

		private void keypad1_NumberClick(object sender, EventArgs e) {
			textBox1.Text += keypad1.raisedNumber.ToString();
		}
		private void keypad1_OkClick(object sender, EventArgs e) {
			TryUnlock();
		}
		public void TryUnlock() {
			string command = $"adb shell input text {textBox1.Text} && adb shell input keyevent 66";
			Form1.adb(command);
			DeviceList();
		}
		public void DeviceList() {
			richTextBox2.Text = Form1.adb("adb devices").TrimEnd();
			if(richTextBox2.Text.Contains("unauthorized") || richTextBox2.Text.Split('\n').Length < 2) {
				pictureBox1.Image = Properties.Resources.lockedShadow;
			}
			else {
				pictureBox1.Image = Properties.Resources.unlockedShadow;
			}

		}
	}
}
