using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace randz.CustomControls {
	[ToolboxBitmap(typeof(VerticalLabel), "VerticalLabel.ico")]
	public class VerticalLabel : Control {
		private string labelText;
		private DrawMode _dm = DrawMode.BottomUp;
		private bool _transparentBG = false;
		private bool useFluent = false;
		private bool hovering = false;
		

		private System.Drawing.Text.TextRenderingHint _renderMode = System.Drawing.Text.TextRenderingHint.SystemDefault;

		private Color baseColor = Color.FromArgb(200, 200, 200);
		private Color hoverColor = Color.FromArgb(230, 230, 230);
		private Color pressOverlayColor = Color.FromArgb(100, 100, 100);
		private float gradientLightAmount = 0.5f;
		private float gradientDarkAmount = 0;

		[Category("Appearance")]
		[Description("Enable or disable Fluent-style rendering.")]
		public bool UseFluent {
			get => useFluent;
			set {
				useFluent = value;
				if(useFluent) {
					InvalidateRegion();
				}
				else {
					Region = null;
					Invalidate();
				}
			}
		}
		[Category("Appearance"), Description("Round corner radius.")]
		public int CornerRadius = 7;

		[Category("Properties"), Description("Rendering mode.")]
		public System.Drawing.Text.TextRenderingHint RenderingMode {
			get => _renderMode;
			set {
				_renderMode = value;
				Invalidate();
			}
		}

		[Category("Properties"), Description("Whether the background is transparent.")]
		public bool TransparentBackground {
			get => _transparentBG;
			set {
				_transparentBG = value;
				Invalidate();
			}
		}

		public VerticalLabel() {
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
					 ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
			InitializeComponent();
		}

		private void InitializeComponent() {
			this.Size = new Size(24, 100);
		}

		private void InvalidateRegion() {
			using(GraphicsPath path = RoundedRect(ClientRectangle, CornerRadius)) {
				Region = new Region(path);
			}
			Invalidate();
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			if(UseFluent) {
				InvalidateRegion();
			}
			else {
				Region = null;
			}
		}

		protected override void OnHandleCreated(EventArgs e) {
			base.OnHandleCreated(e);
			if(UseFluent) {
				InvalidateRegion();
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e) {
			if(UseFluent) {
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				Color currentColor = hovering ? hoverColor : baseColor;

				Color topColor = BlendColors(currentColor, Color.White, gradientLightAmount);
				Color bottomColor = BlendColors(currentColor, Color.Black, gradientDarkAmount);

				using(GraphicsPath path = RoundedRect(ClientRectangle, CornerRadius))
				using(LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, topColor, bottomColor, LinearGradientMode.Vertical)) {
					e.Graphics.FillPath(brush, path);
				}
			}
			else if(!_transparentBG) {
				using(SolidBrush brush = new SolidBrush(BackColor)) {
					e.Graphics.FillRectangle(brush, ClientRectangle);
				}
			}
			else {
				base.OnPaintBackground(e);
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.TextRenderingHint = _renderMode;

			Color textColor = ForeColor;
			if(hovering) {
				textColor = Color.FromArgb(
					(int)(textColor.R * 0.9),
					(int)(textColor.G * 0.9),
					(int)(textColor.B * 0.9));
			}

			using(SolidBrush textBrush = new SolidBrush(textColor)) {
				DrawVerticalText(e.Graphics, textBrush);
			}
		}

		private void DrawVerticalText(Graphics g, Brush brush) {
			float width = Width;
			float height = Height;

			if(_dm == DrawMode.BottomUp) {
				g.TranslateTransform(0, height);
				g.RotateTransform(270);
				g.DrawString(labelText, Font, brush, 0, 0);
				g.ResetTransform();
			}
			else {
				g.TranslateTransform(width, 0);
				g.RotateTransform(90);
				g.DrawString(labelText, Font, brush, 0, 0, StringFormat.GenericTypographic);
				g.ResetTransform();
			}
		}

		protected override void OnMouseEnter(EventArgs e) {
			base.OnMouseEnter(e);
			hovering = true;
			if(UseFluent) Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			hovering = false;
			if(UseFluent) Invalidate();
		}

		public override string Text {
			get => labelText;
			set {
				labelText = value;
				Invalidate();
			}
		}

		public DrawMode TextDrawMode {
			get => _dm;
			set {
				_dm = value;
				Invalidate();
			}
		}

		private GraphicsPath RoundedRect(Rectangle bounds, int radius) {
			int diameter = radius * 2;
			GraphicsPath path = new GraphicsPath();
			path.StartFigure();
			path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
			path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
			path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
			path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
			path.CloseFigure();
			return path;
		}

		private Color BlendColors(Color color1, Color color2, float amount) {
			byte r = (byte)((color1.R * (1 - amount)) + color2.R * amount);
			byte g = (byte)((color1.G * (1 - amount)) + color2.G * amount);
			byte b = (byte)((color1.B * (1 - amount)) + color2.B * amount);
			return Color.FromArgb(r, g, b);
		}

		protected override CreateParams CreateParams {
			get {
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT for transparency support
				return cp;
			}
		}
	}

	public enum DrawMode {
		BottomUp = 1,
		TopBottom
	}
}
