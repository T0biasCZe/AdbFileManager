using Timer = System.Windows.Forms.Timer;

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
		///  Required method for Designer support_do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			dataGridView_soubory = new DataGridView();
			timer1 = new Timer(components);
			cur_path = new TextBox();
			toolTip1 = new ToolTip(components);
			checkBox_android6fix_fastmode = new CheckBox();
			checkBox_unwrapfolders = new CheckBox();
			checkBox_preview = new CheckBox();
			checkBox_android6fix = new CheckBox();
			verticalLabel_makedir = new randz.CustomControls.VerticalLabel();
			explorer_path = new TextBox();
			button_unlock = new FluentButton();
			button1 = new FluentButton();
			button_android2pc = new FluentButton();
			button_pc2android = new FluentButton();
			button_forward = new Button();
			button_back = new Button();
			deco_panel4 = new Panel();
			button_openSettings = new FluentButton();
			panel_dolniTlacitka = new Panel();
			comboBox_device = new ComboBox();
			button_console = new Button();
			deco_panel6 = new Panel();
			comboBox_lang = new ComboBox();
			label_version = new LinkLabel();
			checkBox_filedate = new CheckBox();
			panel_tlacitkaUprostred = new Panel();
			verticalLabel_refresh = new randz.CustomControls.VerticalLabel();
			deco_panel1 = new Panel();
			deco_panel5 = new Panel();
			deco_panel3 = new Panel();
			deco_panel2 = new Panel();
			explorerBrowser1 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser();
			((System.ComponentModel.ISupportInitialize)dataGridView_soubory).BeginInit();
			deco_panel4.SuspendLayout();
			panel_dolniTlacitka.SuspendLayout();
			panel_tlacitkaUprostred.SuspendLayout();
			SuspendLayout();
			// 
			// dataGridView_soubory
			// 
			resources.ApplyResources(dataGridView_soubory, "dataGridView_soubory");
			dataGridView_soubory.AllowUserToAddRows = false;
			dataGridView_soubory.AllowUserToDeleteRows = false;
			dataGridView_soubory.AllowUserToResizeRows = false;
			dataGridView_soubory.BackgroundColor = SystemColors.ButtonHighlight;
			dataGridView_soubory.GridColor = Color.White;
			dataGridView_soubory.Name = "dataGridView_soubory";
			dataGridView_soubory.RowHeadersVisible = false;
			dataGridView_soubory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			toolTip1.SetToolTip(dataGridView_soubory, resources.GetString("dataGridView_soubory.ToolTip"));
			dataGridView_soubory.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
			dataGridView_soubory.ColumnHeaderMouseDoubleClick += dataGridView1_ColumnHeaderMouseDoubleClick;
			dataGridView_soubory.KeyDown += dataGridView1_KeyDown;
			// 
			// timer1
			// 
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
			// checkBox_android6fix_fastmode
			// 
			resources.ApplyResources(checkBox_android6fix_fastmode, "checkBox_android6fix_fastmode");
			checkBox_android6fix_fastmode.Name = "checkBox_android6fix_fastmode";
			toolTip1.SetToolTip(checkBox_android6fix_fastmode, resources.GetString("checkBox_android6fix_fastmode.ToolTip"));
			checkBox_android6fix_fastmode.UseVisualStyleBackColor = true;
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
			// checkBox_android6fix
			// 
			resources.ApplyResources(checkBox_android6fix, "checkBox_android6fix");
			checkBox_android6fix.Name = "checkBox_android6fix";
			toolTip1.SetToolTip(checkBox_android6fix, resources.GetString("checkBox_android6fix.ToolTip"));
			checkBox_android6fix.UseVisualStyleBackColor = true;
			checkBox_android6fix.CheckedChanged += checkBox_android6fix_CheckedChanged;
			// 
			// verticalLabel_makedir
			// 
			resources.ApplyResources(verticalLabel_makedir, "verticalLabel_makedir");
			verticalLabel_makedir.BackColor = SystemColors.ControlLight;
			verticalLabel_makedir.ForeColor = SystemColors.ControlText;
			verticalLabel_makedir.Name = "verticalLabel_makedir";
			verticalLabel_makedir.RenderingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			verticalLabel_makedir.TextDrawMode = randz.CustomControls.DrawMode.TopBottom;
			toolTip1.SetToolTip(verticalLabel_makedir, resources.GetString("verticalLabel_makedir.ToolTip"));
			verticalLabel_makedir.TransparentBackground = false;
			verticalLabel_makedir.UseFluent = false;
			verticalLabel_makedir.Click += button_makedir_Click;
			// 
			// explorer_path
			// 
			resources.ApplyResources(explorer_path, "explorer_path");
			explorer_path.Name = "explorer_path";
			toolTip1.SetToolTip(explorer_path, resources.GetString("explorer_path.ToolTip"));
			explorer_path.KeyPress += explorer_path_KeyPress;
			// 
			// button_unlock
			// 
			resources.ApplyResources(button_unlock, "button_unlock");
			button_unlock.BackColor = SystemColors.ControlLight;
			button_unlock.FlatAppearance.BorderSize = 0;
			button_unlock.ForeColor = Color.Black;
			button_unlock.Image = Properties.Resources.unlock16;
			button_unlock.Name = "button_unlock";
			toolTip1.SetToolTip(button_unlock, resources.GetString("button_unlock.ToolTip"));
			button_unlock.UseFluent = false;
			button_unlock.UseVisualStyleBackColor = false;
			button_unlock.Click += button_unlock_Click;
			// 
			// button1
			// 
			resources.ApplyResources(button1, "button1");
			button1.BackColor = Color.FromArgb(242, 242, 242);
			button1.ForeColor = Color.Black;
			button1.Name = "button1";
			toolTip1.SetToolTip(button1, resources.GetString("button1.ToolTip"));
			button1.UseFluent = false;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button_android2pc
			// 
			resources.ApplyResources(button_android2pc, "button_android2pc");
			button_android2pc.BackColor = SystemColors.ControlLight;
			button_android2pc.FlatAppearance.BorderSize = 0;
			button_android2pc.ForeColor = Color.Black;
			button_android2pc.Name = "button_android2pc";
			toolTip1.SetToolTip(button_android2pc, resources.GetString("button_android2pc.ToolTip"));
			button_android2pc.UseFluent = false;
			button_android2pc.UseVisualStyleBackColor = false;
			button_android2pc.Click += android2pc_Click;
			// 
			// button_pc2android
			// 
			resources.ApplyResources(button_pc2android, "button_pc2android");
			button_pc2android.BackColor = SystemColors.ControlLight;
			button_pc2android.FlatAppearance.BorderSize = 0;
			button_pc2android.ForeColor = Color.Black;
			button_pc2android.Name = "button_pc2android";
			toolTip1.SetToolTip(button_pc2android, resources.GetString("button_pc2android.ToolTip"));
			button_pc2android.UseFluent = false;
			button_pc2android.UseVisualStyleBackColor = false;
			button_pc2android.Click += pc2android_Click;
			// 
			// button_forward
			// 
			resources.ApplyResources(button_forward, "button_forward");
			button_forward.BackColor = Color.Transparent;
			button_forward.FlatAppearance.BorderSize = 0;
			button_forward.Name = "button_forward";
			toolTip1.SetToolTip(button_forward, resources.GetString("button_forward.ToolTip"));
			button_forward.UseVisualStyleBackColor = false;
			button_forward.Click += button_forward_Click;
			button_forward.MouseDown += buttonforward_MouseDown;
			button_forward.MouseEnter += buttonforward_MouseEnter;
			button_forward.MouseLeave += buttonforward_MouseLeave;
			button_forward.MouseUp += buttonforward_MouseUp;
			// 
			// button_back
			// 
			resources.ApplyResources(button_back, "button_back");
			button_back.BackColor = Color.Transparent;
			button_back.FlatAppearance.BorderSize = 0;
			button_back.Name = "button_back";
			toolTip1.SetToolTip(button_back, resources.GetString("button_back.ToolTip"));
			button_back.UseVisualStyleBackColor = false;
			button_back.Click += button_back_Click;
			button_back.MouseDown += buttonback_MouseDown;
			button_back.MouseEnter += buttonback_MouseEnter;
			button_back.MouseLeave += buttonback_MouseLeave;
			button_back.MouseUp += buttonback_MouseUp;
			// 
			// deco_panel4
			// 
			resources.ApplyResources(deco_panel4, "deco_panel4");
			deco_panel4.BackColor = Color.Gray;
			deco_panel4.Controls.Add(button_openSettings);
			deco_panel4.Name = "deco_panel4";
			toolTip1.SetToolTip(deco_panel4, resources.GetString("deco_panel4.ToolTip"));
			// 
			// button_openSettings
			// 
			resources.ApplyResources(button_openSettings, "button_openSettings");
			button_openSettings.BackColor = SystemColors.ControlLight;
			button_openSettings.FlatAppearance.BorderSize = 0;
			button_openSettings.ForeColor = Color.Black;
			button_openSettings.Name = "button_openSettings";
			toolTip1.SetToolTip(button_openSettings, resources.GetString("button_openSettings.ToolTip"));
			button_openSettings.UseFluent = false;
			button_openSettings.UseVisualStyleBackColor = false;
			button_openSettings.Click += button_openSettings_Click;
			// 
			// panel_dolniTlacitka
			// 
			resources.ApplyResources(panel_dolniTlacitka, "panel_dolniTlacitka");
			panel_dolniTlacitka.BackColor = Color.FromArgb(192, 255, 255);
			panel_dolniTlacitka.Controls.Add(comboBox_device);
			panel_dolniTlacitka.Controls.Add(button_console);
			panel_dolniTlacitka.Controls.Add(button_unlock);
			panel_dolniTlacitka.Controls.Add(deco_panel6);
			panel_dolniTlacitka.Controls.Add(deco_panel4);
			panel_dolniTlacitka.Controls.Add(checkBox_android6fix_fastmode);
			panel_dolniTlacitka.Controls.Add(comboBox_lang);
			panel_dolniTlacitka.Controls.Add(checkBox_unwrapfolders);
			panel_dolniTlacitka.Controls.Add(checkBox_preview);
			panel_dolniTlacitka.Controls.Add(checkBox_android6fix);
			panel_dolniTlacitka.Controls.Add(label_version);
			panel_dolniTlacitka.Controls.Add(checkBox_filedate);
			panel_dolniTlacitka.Name = "panel_dolniTlacitka";
			toolTip1.SetToolTip(panel_dolniTlacitka, resources.GetString("panel_dolniTlacitka.ToolTip"));
			panel_dolniTlacitka.Paint += panel_dolniTlacitka_Paint;
			// 
			// comboBox_device
			// 
			resources.ApplyResources(comboBox_device, "comboBox_device");
			comboBox_device.FormattingEnabled = true;
			comboBox_device.Items.AddRange(new object[] { resources.GetString("comboBox_device.Items"), resources.GetString("comboBox_device.Items1") });
			comboBox_device.Name = "comboBox_device";
			toolTip1.SetToolTip(comboBox_device, resources.GetString("comboBox_device.ToolTip"));
			comboBox_device.SelectedIndexChanged += comboBox_device_SelectedIndexChanged;
			// 
			// button_console
			// 
			resources.ApplyResources(button_console, "button_console");
			button_console.BackColor = Color.Transparent;
			button_console.FlatAppearance.BorderSize = 0;
			button_console.Name = "button_console";
			toolTip1.SetToolTip(button_console, resources.GetString("button_console.ToolTip"));
			button_console.UseVisualStyleBackColor = false;
			button_console.Click += button1_Click;
			// 
			// deco_panel6
			// 
			resources.ApplyResources(deco_panel6, "deco_panel6");
			deco_panel6.BackColor = Color.Gray;
			deco_panel6.Name = "deco_panel6";
			toolTip1.SetToolTip(deco_panel6, resources.GetString("deco_panel6.ToolTip"));
			// 
			// comboBox_lang
			// 
			resources.ApplyResources(comboBox_lang, "comboBox_lang");
			comboBox_lang.FormattingEnabled = true;
			comboBox_lang.Name = "comboBox_lang";
			toolTip1.SetToolTip(comboBox_lang, resources.GetString("comboBox_lang.ToolTip"));
			// 
			// label_version
			// 
			resources.ApplyResources(label_version, "label_version");
			label_version.Name = "label_version";
			label_version.TabStop = true;
			toolTip1.SetToolTip(label_version, resources.GetString("label_version.ToolTip"));
			label_version.LinkClicked += version_LinkClicked;
			// 
			// checkBox_filedate
			// 
			resources.ApplyResources(checkBox_filedate, "checkBox_filedate");
			checkBox_filedate.Name = "checkBox_filedate";
			toolTip1.SetToolTip(checkBox_filedate, resources.GetString("checkBox_filedate.ToolTip"));
			checkBox_filedate.UseVisualStyleBackColor = true;
			// 
			// panel_tlacitkaUprostred
			// 
			resources.ApplyResources(panel_tlacitkaUprostred, "panel_tlacitkaUprostred");
			panel_tlacitkaUprostred.Controls.Add(verticalLabel_makedir);
			panel_tlacitkaUprostred.Controls.Add(verticalLabel_refresh);
			panel_tlacitkaUprostred.Controls.Add(button_android2pc);
			panel_tlacitkaUprostred.Controls.Add(button_pc2android);
			panel_tlacitkaUprostred.Controls.Add(deco_panel1);
			panel_tlacitkaUprostred.Controls.Add(deco_panel5);
			panel_tlacitkaUprostred.Controls.Add(deco_panel3);
			panel_tlacitkaUprostred.Controls.Add(deco_panel2);
			panel_tlacitkaUprostred.Name = "panel_tlacitkaUprostred";
			toolTip1.SetToolTip(panel_tlacitkaUprostred, resources.GetString("panel_tlacitkaUprostred.ToolTip"));
			panel_tlacitkaUprostred.Paint += panel_tlacitkaUprostred_Paint;
			// 
			// verticalLabel_refresh
			// 
			resources.ApplyResources(verticalLabel_refresh, "verticalLabel_refresh");
			verticalLabel_refresh.BackColor = SystemColors.ControlLight;
			verticalLabel_refresh.ForeColor = SystemColors.ControlText;
			verticalLabel_refresh.Name = "verticalLabel_refresh";
			verticalLabel_refresh.RenderingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			verticalLabel_refresh.TextDrawMode = randz.CustomControls.DrawMode.TopBottom;
			toolTip1.SetToolTip(verticalLabel_refresh, resources.GetString("verticalLabel_refresh.ToolTip"));
			verticalLabel_refresh.TransparentBackground = false;
			verticalLabel_refresh.UseFluent = false;
			verticalLabel_refresh.Click += verticalLabel1_Click;
			// 
			// deco_panel1
			// 
			resources.ApplyResources(deco_panel1, "deco_panel1");
			deco_panel1.BackColor = Color.Gray;
			deco_panel1.ForeColor = SystemColors.ControlText;
			deco_panel1.Name = "deco_panel1";
			toolTip1.SetToolTip(deco_panel1, resources.GetString("deco_panel1.ToolTip"));
			// 
			// deco_panel5
			// 
			resources.ApplyResources(deco_panel5, "deco_panel5");
			deco_panel5.BackColor = Color.Gray;
			deco_panel5.Name = "deco_panel5";
			toolTip1.SetToolTip(deco_panel5, resources.GetString("deco_panel5.ToolTip"));
			// 
			// deco_panel3
			// 
			resources.ApplyResources(deco_panel3, "deco_panel3");
			deco_panel3.BackColor = Color.Gray;
			deco_panel3.Name = "deco_panel3";
			toolTip1.SetToolTip(deco_panel3, resources.GetString("deco_panel3.ToolTip"));
			// 
			// deco_panel2
			// 
			resources.ApplyResources(deco_panel2, "deco_panel2");
			deco_panel2.BackColor = Color.Gray;
			deco_panel2.Name = "deco_panel2";
			toolTip1.SetToolTip(deco_panel2, resources.GetString("deco_panel2.ToolTip"));
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
			// Form1
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(explorer_path);
			Controls.Add(explorerBrowser1);
			Controls.Add(cur_path);
			Controls.Add(dataGridView_soubory);
			Controls.Add(panel_tlacitkaUprostred);
			Controls.Add(button_back);
			Controls.Add(button_forward);
			Controls.Add(panel_dolniTlacitka);
			Name = "Form1";
			toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
			FormClosing += Form1_FormClosing;
			FormClosed += Form1_FormClosed;
			Load += Form1_Load;
			Resize += Form1_Resize;
			((System.ComponentModel.ISupportInitialize)dataGridView_soubory).EndInit();
			deco_panel4.ResumeLayout(false);
			panel_dolniTlacitka.ResumeLayout(false);
			panel_dolniTlacitka.PerformLayout();
			panel_tlacitkaUprostred.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}




		#endregion
		public DataGridView dataGridView_soubory;
		private System.Windows.Forms.Timer timer1;
		private ToolTip toolTip1;
		private CheckBox checkBox_android6fix_fastmode;
		public ComboBox comboBox_lang;
		private CheckBox checkBox_unwrapfolders;
		private CheckBox checkBox_preview;
		private FluentButton button1;
		public CheckBox checkBox_android6fix;
		private CheckBox checkBox_filedate;
		private Panel panel_tlacitkaUprostred;
		public Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser explorerBrowser1;
		public Panel deco_panel1;
		public Panel deco_panel2;
		public Panel deco_panel3;
		public Panel deco_panel4;
		public Panel deco_panel5;
		public Button button_forward;
		public Button button_back;
		public randz.CustomControls.VerticalLabel verticalLabel_makedir;
		public FluentButton button_android2pc;
		public randz.CustomControls.VerticalLabel verticalLabel_refresh;
		public FluentButton button_unlock;
		public FluentButton button_pc2android;
		public FluentButton button_openSettings;
		public Panel deco_panel6;
		public Button button_console;
		public LinkLabel label_version;
		public Panel panel_dolniTlacitka;
		public TextBox cur_path;
		public TextBox explorer_path;
		public ComboBox comboBox_device;
	}
}