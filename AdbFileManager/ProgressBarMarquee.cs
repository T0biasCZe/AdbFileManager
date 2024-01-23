using Microsoft.WindowsAPICodePack.Taskbar;
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
	public partial class ProgressBarMarquee : Form {
		public bool cancel = false;
		public ProgressBarMarquee() {
			InitializeComponent();
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
		}
		public void set(string text, string title) {
			this.Text = title;
			this.label1.Text = text;
		}

		private void button1_Click(object sender, EventArgs e) {
			cancel = true;
		}
		public void delete() {
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
			this.Close();
		}
		public void redraw() {
			progressBar1.Invalidate();
			progressBar1.Update();
			progressBar1.Refresh();
			this.Invalidate();
			this.Update();
			this.Refresh();
		}
	}
}
