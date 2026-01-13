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
	public partial class Form2 : Form {
		private static readonly ResourceManager rm = new ResourceManager("AdbFileManager.strings", Assembly.GetExecutingAssembly());

		public Form2() {
			InitializeComponent();
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
			label_freezewarn.Text = rm.GetString("copy_freeze_warn");
		}
		public void Update(int current, int max, string source, string dest, string _filename, float percentage = -1) {
			Console.WriteLine($"cur: {current} max: {max} perc: {percentage}");

			fromto.Text = rm.GetString("fromto").Replace("{source}", source).Replace("{dest}", dest);


			filename.Text = _filename;
			progress.Text = $"{percentage}% {current}/{max}";

			if(percentage >= 0) {
				progressBar1.Maximum = 10000;
				progressBar1.Value = (int)(percentage * 100);
			} else{
				progressBar1.Maximum = max;
				progressBar1.Value = current;
			}

			if(percentage >= 0) {
				int taskbarValue = (int)(percentage * 100);

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
