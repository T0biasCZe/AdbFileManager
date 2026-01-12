using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DarkModeControls {
	public class DarkCommandLink : Button {
		private const int BS_COMMANDLINK = 0x0000000E;

		public Color MainTextColor { get; set; } = Color.White;
		public Color NoteTextColor { get; set; } = Color.LightGray;
		public string Note { get; set; } = "";

		public DarkCommandLink() {
			FlatStyle = FlatStyle.System;
		}

		protected override CreateParams CreateParams {
			get {
				var cp = base.CreateParams;
				cp.Style |= BS_COMMANDLINK;
				return cp;
			}
		}

		protected override void WndProc(ref Message m) {
			if(m.Msg == WM_PAINT) {
				base.WndProc(ref m);
				DrawCustomText();
				return;
			}

			base.WndProc(ref m);
		}

		private void DrawCustomText() {
			using(Graphics g = Graphics.FromHwnd(this.Handle)) {
				Rectangle rect = this.ClientRectangle;

				TextRenderer.DrawText(
					g,
					this.Text,
					new Font("Segoe UI", 12, FontStyle.Regular),
					new Point(29, 10),
					MainTextColor,
					TextFormatFlags.WordBreak
				);
			}
		}

		private const int WM_PAINT = 0x000F;
	}
}
