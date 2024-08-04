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
	public partial class keypad : UserControl {
		public keypad() {
			InitializeComponent();
		}
		public int raisedNumber = 0;
		private void button_number_Click(object sender, EventArgs e) {
			Button button = (Button)sender;
			raisedNumber = int.Parse(button.Text);
			NumberClick?.Invoke(this, e);
		}
		private void button_ok_Click(object sender, EventArgs e) {
			OkClick?.Invoke(this, e);
		}

		public event EventHandler OkClick;
		//create number click event handler, that will give the subscriber the number that was clicked through event args
		public event EventHandler NumberClick;

	}
}
