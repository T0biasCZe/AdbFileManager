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
		}

		private async void button1_Click(object sender, EventArgs e) {
			string ip = textBox1.Text.Trim();
			string port = textBox2.Text.Trim();
			string pairingCode = textBox3.Text.Trim();
			if(string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port)) {
				MessageBox.Show("Please enter both IP and Port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(string.IsNullOrEmpty(pairingCode)) {
				MessageBox.Show("Please enter the pairing code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					MessageBox.Show("The pairing process timed out. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if(process.ExitCode != 0) {
					MessageBox.Show("An error occurred during the pairing process:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else {
					MessageBox.Show("Pairing finished!\n" + output, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
			}
			catch(Exception ex) {
				MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button_reconnect_Click(object sender, EventArgs e) {
			string ip = textBox1.Text.Trim();
			string port = textBox2.Text.Trim();
			if(string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port)) {
				MessageBox.Show("Please enter both IP and Port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show("Reconnect command finished:\n" + output, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception ex) {
				MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
