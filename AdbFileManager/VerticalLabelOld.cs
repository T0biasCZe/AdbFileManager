using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace randz.CustomControls {
    /// <summary>
    /// A custom windows control to display text vertically
    /// </summary>
    [ToolboxBitmap(typeof(VerticalLabelOld), "VerticalLabel.ico")]
    public class VerticalLabelOld : System.Windows.Forms.Control {
        private string labelText;
        private DrawMode _dm = DrawMode.BottomUp;
        private bool _transparentBG = false;
        System.Drawing.Text.TextRenderingHint _renderMode = System.Drawing.Text.TextRenderingHint.SystemDefault;

        private System.ComponentModel.Container components = new System.ComponentModel.Container();

        /// <summary>
        /// VerticalLabel constructor
        /// </summary>
        public VerticalLabelOld() {
            base.CreateControl();
            InitializeComponent();
            SetStyle(System.Windows.Forms.ControlStyles.Opaque, true);
        }

        /// <summary>
        /// Dispose override method
        /// </summary>
        /// <param name="disposing">boolean parameter</param>
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(!((components == null))) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent() {
            this.Size = new System.Drawing.Size(24, 100);
        }

        /// <summary>
        /// OnPaint override. This is where the text is rendered vertically.
        /// </summary>
        /// <param name="e">PaintEventArgs</param>
        private bool hovering = false;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) {
            float vlblControlWidth;
            float vlblControlHeight;
            float vlblTransformX;
            float vlblTransformY;

            Color controlBackColor = BackColor;
            if(hovering) {
                controlBackColor = Color.FromArgb((int)(controlBackColor.R * 0.9), (int)(controlBackColor.G * 0.9), (int)(controlBackColor.B * 0.9));
			}
            Pen labelBorderPen;
            SolidBrush labelBackColorBrush;

            if(_transparentBG) {
                labelBorderPen = new Pen(Color.Empty, 0);
                labelBackColorBrush = new SolidBrush(Color.Empty);
            }
            else {
                labelBorderPen = new Pen(controlBackColor, 0);
                labelBackColorBrush = new SolidBrush(controlBackColor);
            }

            SolidBrush labelForeColorBrush = new SolidBrush(base.ForeColor);
            base.OnPaint(e);

            vlblControlWidth = this.Size.Width;
            vlblControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.TextRenderingHint = this._renderMode;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if(this.TextDrawMode == DrawMode.BottomUp) {
                vlblTransformX = 0;
                vlblTransformY = vlblControlHeight;
                e.Graphics.TranslateTransform(vlblTransformX, vlblTransformY);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0);
            }
            else {
                vlblTransformX = vlblControlWidth;
                vlblTransformY = vlblControlHeight;
                e.Graphics.TranslateTransform(vlblControlWidth, 0);
                e.Graphics.RotateTransform(90);
                e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0, StringFormat.GenericTypographic);
            }
        }
		protected override void OnMouseEnter(EventArgs e) {
			base.OnMouseEnter(e);
            hovering = true;
            Refresh();
		}
        protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			hovering = false;
            Refresh();
		}
		/// <summary>
		/// 
		/// </summary>
		protected override CreateParams CreateParams//v1.10 
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return cp;
            }
        }

        private void VerticalTextBox_Resize(object sender, System.EventArgs e) {
            Invalidate();
        }
        /// <summary>
        /// Graphics rendering mode. Supprot for antialiasing.
        /// </summary>
        [Category("Properties"), Description("Rendering mode.")]
        public System.Drawing.Text.TextRenderingHint RenderingMode {
            get { return _renderMode; }
            set { _renderMode = value; }
        }
        /// <summary>
        /// The text to be displayed in the control
        /// </summary>
        [Category("VerticalLabel"), Description("Text is displayed vertically in container.")]
        public override string Text {
            get {
                return labelText;
            }
            set {
                labelText = value;
                Invalidate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Category("Properties"), Description("Whether the text will be drawn from Bottom or from Top.")]
        public DrawMode TextDrawMode {
            get { return _dm; }
            set { _dm = value; }
        }
        [Category("Properties"), Description("Whether the text will be drawn with transparent background or not.")]
        public bool TransparentBackground {
            get { return _transparentBG; }
            set { _transparentBG = value; }
        }
    }
}
