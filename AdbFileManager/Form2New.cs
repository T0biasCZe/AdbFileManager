using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace AdbFileManager {
	public partial class Form2New : Form {
		private static readonly ResourceManager rm = new ResourceManager("AdbFileManager.strings", Assembly.GetExecutingAssembly());

		public Form2New() {
			InitializeComponent();
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
			label_freezewarn.Text = rm.GetString("copy_freeze_warn");
		}
		public void Update(int current, int max, string source, string dest, string _filename, float totalPercentage, float filePercentage) {
			Console.WriteLine($"cur: {current} max: {max} perc: {totalPercentage}");

			fromto.Text = rm.GetString("fromto").Replace("{source}", source).Replace("{dest}", dest);


			filename.Text = _filename;
			//total percentage as string with 1 decimal point
			
			progress.Text = $"{string.Format("{0:F1}", totalPercentage)}% {current}/{max}";

			if(totalPercentage >= 0) {
				progressBar1.Maximum = 10000;
				progressBar1.Value = (int)(totalPercentage * 100);
			} else{
				progressBar1.Maximum = max;
				progressBar1.Value = current;
			}

			progressBar2.Maximum = 10000;
			progressBar2.Value = (int)(filePercentage * 100);
			richTextBox1.Text = string.Format("{0:F1}%", filePercentage);

			if(totalPercentage >= 0) {
				int taskbarValue = (int)(totalPercentage * 100);

				if(taskbarValue < 0) taskbarValue = 0;
				if(taskbarValue > 10000) taskbarValue = 10000;

				TaskbarManager.Instance.SetProgressValue(taskbarValue, 10000);
			}
			this.Invalidate();
			this.Refresh();
		}
		public void delete() {
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
			this.Close();
		}

		private void timer1_Tick(object sender, EventArgs e) {
			pictureBox1.Invalidate();
			pictureBox1.Refresh();
		}

		private void Form2_FormClosed(object sender, FormClosedEventArgs e) {
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
			// Cancel the running ADB process when progress dialog is closed
			AdbProgressRunner.Cancel();
		}
		public static void set_language() {
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");
		}
	}
}
