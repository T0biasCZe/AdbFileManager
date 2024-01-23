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
		public Form2() {
			InitializeComponent();
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

			ResourceManager rm = new ResourceManager("AdbFileManager.strings", Assembly.GetExecutingAssembly());
			label_freezewarn.Text = rm.GetString("copy_freeze_warn");
		}
		public void update(int current, int max, string source, string dest, string filenamee) {
			//set fromto.Text to variable "fromto" in resource strings.resx
			ResourceManager rm = new ResourceManager("AdbFileManager.strings", Assembly.GetExecutingAssembly());
			fromto.Text = rm.GetString("fromto").Replace("{source}", source).Replace("{dest}", dest);


			filename.Text = filenamee;
			progress.Text = $"{current}/{max}";
			progressBar1.Maximum = max;
			progressBar1.Value = current;
			TaskbarManager.Instance.SetProgressValue(current, max);
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
		}
		public static void set_language() {
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");
		}
	}
}
