namespace AdbFileManager {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			textBox1 = new TextBox();
			dataGridView1 = new DataGridView();
			textBox2 = new TextBox();
			textBox3 = new TextBox();
			explorerBrowser1 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser();
			android2pc = new Button();
			pc2android = new Button();
			verticalLabel1 = new randz.CustomControls.VerticalLabel();
			verticalLabel2 = new randz.CustomControls.VerticalLabel();
			timer1 = new System.Windows.Forms.Timer(components);
			cur_path = new TextBox();
			panel1 = new Panel();
			button_back = new Button();
			button_forward = new Button();
			explorer_path = new TextBox();
			panel3 = new Panel();
			panel2 = new Panel();
			comboBox_lang = new ComboBox();
			checkBox_unwrapfolders = new CheckBox();
			checkBox_preview = new CheckBox();
			button1 = new Button();
			checkBox_android6fix = new CheckBox();
			version = new LinkLabel();
			checkBox_filedate = new CheckBox();
			toolTip1 = new ToolTip(components);
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			panel1.SuspendLayout();
			panel3.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// textBox1
			// 
			resources.ApplyResources(textBox1, "textBox1");
			textBox1.Name = "textBox1";
			toolTip1.SetToolTip(textBox1, resources.GetString("textBox1.ToolTip"));
			// 
			// dataGridView1
			// 
			resources.ApplyResources(dataGridView1, "dataGridView1");
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
			dataGridView1.GridColor = Color.White;
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.RowTemplate.Height = 25;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			toolTip1.SetToolTip(dataGridView1, resources.GetString("dataGridView1.ToolTip"));
			dataGridView1.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
			dataGridView1.ColumnHeaderMouseDoubleClick += dataGridView1_ColumnHeaderMouseDoubleClick;
			dataGridView1.KeyDown += dataGridView1_KeyDown;
			// 
			// textBox2
			// 
			resources.ApplyResources(textBox2, "textBox2");
			textBox2.Name = "textBox2";
			toolTip1.SetToolTip(textBox2, resources.GetString("textBox2.ToolTip"));
			// 
			// textBox3
			// 
			resources.ApplyResources(textBox3, "textBox3");
			textBox3.Name = "textBox3";
			toolTip1.SetToolTip(textBox3, resources.GetString("textBox3.ToolTip"));
			// 
			// explorerBrowser1
			// 
			resources.ApplyResources(explorerBrowser1, "explorerBrowser1");
			explorerBrowser1.Name = "explorerBrowser1";
			explorerBrowser1.PropertyBagName = "Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser";
			toolTip1.SetToolTip(explorerBrowser1, resources.GetString("explorerBrowser1.ToolTip"));
			explorerBrowser1.NavigationComplete += explorerBrowser1_NavigationComplete;
			explorerBrowser1.Load += explorerBrowser1_Load;
			explorerBrowser1.PreviewKeyDown += explorerBrowser1_PreviewKeyDown;
			// 
			// android2pc
			// 
			resources.ApplyResources(android2pc, "android2pc");
			android2pc.FlatAppearance.BorderSize = 3;
			android2pc.Name = "android2pc";
			toolTip1.SetToolTip(android2pc, resources.GetString("android2pc.ToolTip"));
			android2pc.UseVisualStyleBackColor = true;
			android2pc.Click += android2pc_Click;
			// 
			// pc2android
			// 
			resources.ApplyResources(pc2android, "pc2android");
			pc2android.FlatAppearance.BorderSize = 3;
			pc2android.Name = "pc2android";
			toolTip1.SetToolTip(pc2android, resources.GetString("pc2android.ToolTip"));
			pc2android.UseVisualStyleBackColor = true;
			pc2android.Click += pc2android_Click;
			// 
			// verticalLabel1
			// 
			resources.ApplyResources(verticalLabel1, "verticalLabel1");
			verticalLabel1.BackColor = SystemColors.ControlLight;
			verticalLabel1.ForeColor = SystemColors.ControlText;
			verticalLabel1.Name = "verticalLabel1";
			verticalLabel1.RenderingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			verticalLabel1.TextDrawMode = randz.CustomControls.DrawMode.TopBottom;
			toolTip1.SetToolTip(verticalLabel1, resources.GetString("verticalLabel1.ToolTip"));
			verticalLabel1.TransparentBackground = false;
			verticalLabel1.Click += verticalLabel1_Click;
			verticalLabel1.DoubleClick += verticalLabel1_Click;
			verticalLabel1.MouseClick += verticalLabel1_Click;
			verticalLabel1.MouseDoubleClick += verticalLabel1_Click;
			// 
			// verticalLabel2
			// 
			resources.ApplyResources(verticalLabel2, "verticalLabel2");
			verticalLabel2.BackColor = Color.Gray;
			verticalLabel2.ForeColor = SystemColors.ControlText;
			verticalLabel2.Name = "verticalLabel2";
			verticalLabel2.RenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
			verticalLabel2.TextDrawMode = randz.CustomControls.DrawMode.TopBottom;
			toolTip1.SetToolTip(verticalLabel2, resources.GetString("verticalLabel2.ToolTip"));
			verticalLabel2.TransparentBackground = false;
			verticalLabel2.Click += verticalLabel1_Click;
			verticalLabel2.DoubleClick += verticalLabel1_Click;
			verticalLabel2.MouseClick += verticalLabel1_Click;
			verticalLabel2.MouseDoubleClick += verticalLabel1_Click;
			// 
			// timer1
			// 
			timer1.Enabled = true;
			timer1.Interval = 500;
			timer1.Tick += timer1_Tick;
			// 
			// cur_path
			// 
			resources.ApplyResources(cur_path, "cur_path");
			cur_path.Name = "cur_path";
			toolTip1.SetToolTip(cur_path, resources.GetString("cur_path.ToolTip"));
			cur_path.TextChanged += cur_path_TextChanged;
			// 
			// panel1
			// 
			resources.ApplyResources(panel1, "panel1");
			panel1.Controls.Add(button_back);
			panel1.Controls.Add(button_forward);
			panel1.Controls.Add(explorer_path);
			panel1.Controls.Add(explorerBrowser1);
			panel1.Controls.Add(panel3);
			panel1.Controls.Add(panel2);
			panel1.Name = "panel1";
			toolTip1.SetToolTip(panel1, resources.GetString("panel1.ToolTip"));
			// 
			// button_back
			// 
			resources.ApplyResources(button_back, "button_back");
			button_back.FlatAppearance.BorderSize = 0;
			button_back.Image = Properties.Resources.travel_back_enabled;
			button_back.Name = "button_back";
			toolTip1.SetToolTip(button_back, resources.GetString("button_back.ToolTip"));
			button_back.UseVisualStyleBackColor = true;
			button_back.Click += button_back_Click;
			button_back.MouseDown += buttonback_MouseDown;
			button_back.MouseEnter += buttonback_MouseEnter;
			button_back.MouseLeave += buttonback_MouseLeave;
			button_back.MouseUp += buttonback_MouseUp;
			// 
			// button_forward
			// 
			resources.ApplyResources(button_forward, "button_forward");
			button_forward.FlatAppearance.BorderSize = 0;
			button_forward.Image = Properties.Resources.travel_forward_enabled;
			button_forward.Name = "button_forward";
			toolTip1.SetToolTip(button_forward, resources.GetString("button_forward.ToolTip"));
			button_forward.UseVisualStyleBackColor = true;
			button_forward.Click += button_forward_Click;
			button_forward.MouseDown += buttonforward_MouseDown;
			button_forward.MouseEnter += buttonforward_MouseEnter;
			button_forward.MouseLeave += buttonforward_MouseLeave;
			button_forward.MouseUp += buttonforward_MouseUp;
			// 
			// explorer_path
			// 
			resources.ApplyResources(explorer_path, "explorer_path");
			explorer_path.Name = "explorer_path";
			toolTip1.SetToolTip(explorer_path, resources.GetString("explorer_path.ToolTip"));
			explorer_path.KeyPress += explorer_path_KeyPress;
			// 
			// panel3
			// 
			resources.ApplyResources(panel3, "panel3");
			panel3.Controls.Add(android2pc);
			panel3.Controls.Add(verticalLabel1);
			panel3.Controls.Add(pc2android);
			panel3.Controls.Add(verticalLabel2);
			panel3.Name = "panel3";
			toolTip1.SetToolTip(panel3, resources.GetString("panel3.ToolTip"));
			// 
			// panel2
			// 
			resources.ApplyResources(panel2, "panel2");
			panel2.BackColor = Color.FromArgb(192, 255, 255);
			panel2.Controls.Add(comboBox_lang);
			panel2.Controls.Add(checkBox_unwrapfolders);
			panel2.Controls.Add(checkBox_preview);
			panel2.Controls.Add(button1);
			panel2.Controls.Add(checkBox_android6fix);
			panel2.Controls.Add(version);
			panel2.Controls.Add(checkBox_filedate);
			panel2.Name = "panel2";
			toolTip1.SetToolTip(panel2, resources.GetString("panel2.ToolTip"));
			// 
			// comboBox_lang
			// 
			resources.ApplyResources(comboBox_lang, "comboBox_lang");
			comboBox_lang.FormattingEnabled = true;
			comboBox_lang.Name = "comboBox_lang";
			toolTip1.SetToolTip(comboBox_lang, resources.GetString("comboBox_lang.ToolTip"));
			// 
			// checkBox_unwrapfolders
			// 
			resources.ApplyResources(checkBox_unwrapfolders, "checkBox_unwrapfolders");
			checkBox_unwrapfolders.Name = "checkBox_unwrapfolders";
			toolTip1.SetToolTip(checkBox_unwrapfolders, resources.GetString("checkBox_unwrapfolders.ToolTip"));
			checkBox_unwrapfolders.UseVisualStyleBackColor = true;
			// 
			// checkBox_preview
			// 
			resources.ApplyResources(checkBox_preview, "checkBox_preview");
			checkBox_preview.Name = "checkBox_preview";
			toolTip1.SetToolTip(checkBox_preview, resources.GetString("checkBox_preview.ToolTip"));
			checkBox_preview.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			toolTip1.SetToolTip(button1, resources.GetString("button1.ToolTip"));
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// checkBox_android6fix
			// 
			resources.ApplyResources(checkBox_android6fix, "checkBox_android6fix");
			checkBox_android6fix.Checked = true;
			checkBox_android6fix.CheckState = CheckState.Checked;
			checkBox_android6fix.Name = "checkBox_android6fix";
			toolTip1.SetToolTip(checkBox_android6fix, resources.GetString("checkBox_android6fix.ToolTip"));
			checkBox_android6fix.UseVisualStyleBackColor = true;
			// 
			// version
			// 
			resources.ApplyResources(version, "version");
			version.Name = "version";
			version.TabStop = true;
			toolTip1.SetToolTip(version, resources.GetString("version.ToolTip"));
			version.LinkClicked += version_LinkClicked;
			// 
			// checkBox_filedate
			// 
			resources.ApplyResources(checkBox_filedate, "checkBox_filedate");
			checkBox_filedate.Name = "checkBox_filedate";
			toolTip1.SetToolTip(checkBox_filedate, resources.GetString("checkBox_filedate.ToolTip"));
			checkBox_filedate.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(cur_path);
			Controls.Add(dataGridView1);
			Controls.Add(textBox3);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(panel1);
			Name = "Form1";
			toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel3.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox textBox1;
		private TextBox textBox2;
		public TextBox textBox3;
		private Button android2pc;
		private Button pc2android;
		public DataGridView dataGridView1;
		private randz.CustomControls.VerticalLabel verticalLabel1;
		private randz.CustomControls.VerticalLabel verticalLabel2;
		private System.Windows.Forms.Timer timer1;
		private TextBox cur_path;
		private Panel panel1;
		private CheckBox checkBox_filedate;
		private TextBox explorer_path;
		private LinkLabel version;
		private Button button1;
		private Panel panel2;
		private ToolTip toolTip1;
		public CheckBox checkBox_android6fix;
		private CheckBox checkBox_preview;
		private CheckBox checkBox_unwrapfolders;
		public ComboBox comboBox_lang;
		private Panel panel3;
		private Button button_back;
		private Button button_forward;
		public Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser explorerBrowser1;
	}
}