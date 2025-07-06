using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class FluentButton : Button {
	private bool useFluent = false;

	private Color baseColor = Color.FromArgb(200, 200, 205);
	private Color hoverColor = Color.FromArgb(220, 220, 230);
	private Color pressOverlayColor = Color.FromArgb(100, 100, 105);

	public float gradientLightAmount = 0.5f;
	public float gradientDarkAmount = 0;

	public void EnableDarkMode(){
 		baseColor = Color.FromArgb(50, 50, 55);
		hoverColor = Color.FromArgb(70, 70, 75);
		pressOverlayColor = Color.FromArgb(30, 30, 35);
		currentColor = baseColor;
		gradientLightAmount = 0.2f;
		gradientDarkAmount = 0.5f;
		Invalidate();
	}


	private Color currentColor;

	[Category("Appearance")]
	[Description("Enable or disable Fluent-style rendering.")]
	public bool UseFluent {
		get => useFluent;
		set {
			useFluent = value;
			currentColor = baseColor;
			Invalidate();
		}
	}
	[Category("Appearance"), Description("Round corner radius.")]
	public int CornerRadius = 12;
	public FluentButton() {
		FlatStyle = FlatStyle.Flat;
		FlatAppearance.BorderSize = 0;

		ForeColor = Color.Black;
		Font = new Font("Segoe UI", 10, FontStyle.Regular);
		currentColor = baseColor;

		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
				 ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

		MouseEnter += (s, e) => {
			if(UseFluent) {
				currentColor = hoverColor;
				Invalidate();
			}
		};

		MouseLeave += (s, e) => {
			if(UseFluent) {
				currentColor = baseColor;
				Invalidate();
			}
		};

		MouseDown += (s, e) => {
			if(UseFluent) {
				currentColor = BlendColors(hoverColor, pressOverlayColor, 0.5f);
				Invalidate();
			}
		};

		MouseUp += (s, e) => {
			if(UseFluent) {
				currentColor = hoverColor;
				Invalidate();
			}
		};
	}

	protected override void OnPaint(PaintEventArgs pevent) {
		if(!UseFluent) {
			base.OnPaint(pevent);
			return;
		}

		pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		Rectangle bounds = ClientRectangle;

		Color topColor = BlendColors(currentColor, Color.White, gradientLightAmount);
		Color bottomColor = BlendColors(currentColor, Color.Black, gradientDarkAmount);

		using(GraphicsPath path = RoundedRect(bounds, CornerRadius))
		using(LinearGradientBrush gradientBrush = new LinearGradientBrush(bounds, topColor, bottomColor, LinearGradientMode.Vertical))
		using(SolidBrush textBrush = new SolidBrush(ForeColor))
		using(StringFormat sf = new StringFormat() {
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		}) {
			pevent.Graphics.FillPath(gradientBrush, path);
			pevent.Graphics.DrawString(Text, Font, textBrush, bounds, sf);
		}
	}
	protected override void OnResize(EventArgs e) {
		base.OnResize(e);
		if(UseFluent) {
			using(GraphicsPath path = RoundedRect(ClientRectangle, CornerRadius)) {
				Region = new Region(path);
			}
		}
		else {
			Region = null;
		}
	}

	protected override void OnPaintBackground(PaintEventArgs pevent) {
		if(!UseFluent) {
			base.OnPaintBackground(pevent);
			return;
		}
		pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		pevent.Graphics.Clear(BackColor);
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

	[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
	private static extern IntPtr CreateRoundRectRgn(
		int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
		int nWidthEllipse, int nHeightEllipse);
}
