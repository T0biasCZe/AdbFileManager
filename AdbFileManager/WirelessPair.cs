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
	public partial class WirelessPair : Form {
		public WirelessPair() {
			InitializeComponent();
			ApplyLocalization();
		}

		private void ApplyLocalization() {
			this.Text = AdbFileManager.strings.wireless_title;
			textBox1.PlaceholderText = AdbFileManager.strings.wireless_ipAddress;
			textBox2.PlaceholderText = AdbFileManager.strings.wireless_port;
			textBox3.PlaceholderText = AdbFileManager.strings.wireless_pairingCode;
			button_pair.Text = AdbFileManager.strings.wireless_pair;
			button_reconnect.Text = AdbFileManager.strings.wireless_reconnect;
		}

		private async void button1_Click(object sender, EventArgs e) {
			string ip = textBox1.Text.Trim();
			string port = textBox2.Text.Trim();
			string pairingCode = textBox3.Text.Trim();
			if(string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port)) {
				MessageBox.Show(AdbFileManager.strings.wireless_enterIpPort, AdbFileManager.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(string.IsNullOrEmpty(pairingCode)) {
				MessageBox.Show(AdbFileManager.strings.wireless_enterPairingCode, AdbFileManager.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try {
				var process = new System.Diagnostics.Process();
				process.StartInfo.FileName = "adb";
				process.StartInfo.Arguments = $"pair {ip}:{port}";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.CreateNoWindow = true;

				process.Start();

				// Wait 1 second before sending the pairing code
				await Task.Delay(1000);

				// Write the pairing code followed by a newline
				await process.StandardInput.WriteLineAsync(pairingCode);
				await process.StandardInput.FlushAsync();

				// Optionally, read output (can be shown to user if desired)
				string output = await process.StandardOutput.ReadToEndAsync();
				string error = await process.StandardError.ReadToEndAsync();

				bool finished = process.WaitForExit(30000);
				if(!finished) {
					MessageBox.Show(AdbFileManager.strings.wireless_timeout, AdbFileManager.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if(process.ExitCode != 0) {
					MessageBox.Show(AdbFileManager.strings.wireless_errorOccurred + "\n" + error, AdbFileManager.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else {
					MessageBox.Show(AdbFileManager.strings.wireless_pairingFinished + "\n" + output, AdbFileManager.strings.success, MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
			}
			catch(Exception ex) {
				MessageBox.Show($"{AdbFileManager.strings.exception} {ex.Message}", AdbFileManager.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button_reconnect_Click(object sender, EventArgs e) {
			string ip = textBox1.Text.Trim();
			string port = textBox2.Text.Trim();
			if(string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port)) {
				MessageBox.Show(AdbFileManager.strings.wireless_enterIpPort, AdbFileManager.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try {
				var process = new System.Diagnostics.Process();
				process.StartInfo.FileName = "adb";
				process.StartInfo.Arguments = $"connect {ip}:{port}";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.CreateNoWindow = true;

				process.Start();
				process.WaitForExit(30000);
				string output = process.StandardOutput.ReadToEnd();
				MessageBox.Show(AdbFileManager.strings.wireless_reconnectFinished + "\n" + output, AdbFileManager.strings.info, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception ex) {
				MessageBox.Show($"{AdbFileManager.strings.exception} {ex.Message}", AdbFileManager.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
