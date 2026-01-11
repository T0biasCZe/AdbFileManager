namespace AdbFileManager {
	partial class SettingsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			TabPage tab_behaviour;
			label_trackbarValue = new Label();
			label5 = new Label();
			trackBar_progressWait = new TrackBar();
			checkBox_useLegacyCopy = new CheckBox();
			label_language = new Label();
			comboBox_lang = new ComboBox();
			label3 = new Label();
			checkBox6 = new CheckBox();
			checkBox4 = new CheckBox();
			checkBox_unwrapFolderLegacy = new CheckBox();
			checkBox2 = new CheckBox();
			checkBox1 = new CheckBox();
			checkBox5 = new CheckBox();
			tabControl1 = new TabControl();
			tab_appearance = new TabPage();
			checkBox3 = new CheckBox();
			checkBox_showTwoProgressBars = new CheckBox();
			label4 = new Label();
			checkBox_darkMode = new CheckBox();
			panel2 = new Panel();
			radioButton5 = new RadioButton();
			radioButton3 = new RadioButton();
			radioButton4 = new RadioButton();
			label2 = new Label();
			panel1 = new Panel();
			radioButton2 = new RadioButton();
			radioButton1 = new RadioButton();
			label1 = new Label();
			toolTip1 = new ToolTip(components);
			tab_behaviour = new TabPage();
			tab_behaviour.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_progressWait).BeginInit();
			tabControl1.SuspendLayout();
			tab_appearance.SuspendLayout();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tab_behaviour
			// 
			tab_behaviour.Controls.Add(label_trackbarValue);
			tab_behaviour.Controls.Add(label5);
			tab_behaviour.Controls.Add(trackBar_progressWait);
			tab_behaviour.Controls.Add(checkBox_useLegacyCopy);
			tab_behaviour.Controls.Add(label_language);
			tab_behaviour.Controls.Add(comboBox_lang);
			tab_behaviour.Controls.Add(label3);
			tab_behaviour.Controls.Add(checkBox6);
			tab_behaviour.Controls.Add(checkBox4);
			tab_behaviour.Controls.Add(checkBox_unwrapFolderLegacy);
			tab_behaviour.Controls.Add(checkBox2);
			tab_behaviour.Controls.Add(checkBox1);
			tab_behaviour.Controls.Add(checkBox5);
			tab_behaviour.Location = new Point(4, 24);
			tab_behaviour.Name = "tab_behaviour";
			tab_behaviour.Padding = new Padding(3);
			tab_behaviour.Size = new Size(448, 282);
			tab_behaviour.TabIndex = 0;
			tab_behaviour.Text = "Behaviour";
			tab_behaviour.UseVisualStyleBackColor = true;
			// 
			// label_trackbarValue
			// 
			label_trackbarValue.AutoSize = true;
			label_trackbarValue.Location = new Point(18, 146);
			label_trackbarValue.Name = "label_trackbarValue";
			label_trackbarValue.Size = new Size(35, 15);
			label_trackbarValue.TabIndex = 12;
			label_trackbarValue.Text = "20ms";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(21, 105);
			label5.Name = "label5";
			label5.Size = new Size(110, 15);
			label5.TabIndex = 11;
			label5.Text = "Progress sync delay";
			toolTip1.SetToolTip(label5, "Adjusts the timing how long the copy operation waits for copy progress\r\nDO NOT CHANGE IF NOT SURE WHAT THIS DOES!\r\nDefault 50ms");
			label5.Click += label5_Click;
			// 
			// trackBar_progressWait
			// 
			trackBar_progressWait.Location = new Point(17, 120);
			trackBar_progressWait.Maximum = 50;
			trackBar_progressWait.Name = "trackBar_progressWait";
			trackBar_progressWait.Size = new Size(147, 45);
			trackBar_progressWait.TabIndex = 10;
			trackBar_progressWait.TickFrequency = 5;
			toolTip1.SetToolTip(trackBar_progressWait, "Adjusts the timing how long the copy operation waits for copy progress");
			trackBar_progressWait.Scroll += trackBar_progressWait_Scroll;
			// 
			// checkBox_useLegacyCopy
			// 
			checkBox_useLegacyCopy.AutoSize = true;
			checkBox_useLegacyCopy.Location = new Point(9, 58);
			checkBox_useLegacyCopy.Name = "checkBox_useLegacyCopy";
			checkBox_useLegacyCopy.Size = new Size(155, 19);
			checkBox_useLegacyCopy.TabIndex = 9;
			checkBox_useLegacyCopy.Text = "Use legacy sync copying";
			toolTip1.SetToolTip(checkBox_useLegacyCopy, "When unchecked, modern Async copying with realtime progress parsing will be used\r\nWhen checked, old code with folder unwrapping support will be used.\r\n[NOT RECOMMENDED, BUGGY]");
			checkBox_useLegacyCopy.UseVisualStyleBackColor = true;
			checkBox_useLegacyCopy.CheckedChanged += checkBox_useLegacyCopy_CheckedChanged;
			// 
			// label_language
			// 
			label_language.AutoSize = true;
			label_language.Location = new Point(6, 198);
			label_language.Name = "label_language";
			label_language.Size = new Size(59, 15);
			label_language.TabIndex = 8;
			label_language.Text = "Language";
			// 
			// comboBox_lang
			// 
			comboBox_lang.FormattingEnabled = true;
			comboBox_lang.Items.AddRange(new object[] { "English", "Čeština", "Polski", "Deutsch", "Japanese", "Espanol", "简体中文", "繁體中文" });
			comboBox_lang.Location = new Point(8, 216);
			comboBox_lang.Name = "comboBox_lang";
			comboBox_lang.Size = new Size(121, 23);
			comboBox_lang.TabIndex = 7;
			comboBox_lang.SelectedIndexChanged += comboBox_lang_SelectedIndexChanged;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F);
			label3.ForeColor = Color.Red;
			label3.Location = new Point(155, 235);
			label3.Name = "label3";
			label3.Size = new Size(270, 42);
			label3.TabIndex = 6;
			label3.Text = "THIS TAB IS NOT PROGRAMMED YET \r\n(except lang)";
			// 
			// checkBox6
			// 
			checkBox6.AutoSize = true;
			checkBox6.Location = new Point(267, 56);
			checkBox6.Name = "checkBox6";
			checkBox6.Size = new Size(135, 19);
			checkBox6.TabIndex = 5;
			checkBox6.Text = "Open in last location";
			checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			checkBox4.AutoSize = true;
			checkBox4.Location = new Point(267, 6);
			checkBox4.Name = "checkBox4";
			checkBox4.Size = new Size(114, 19);
			checkBox4.TabIndex = 3;
			checkBox4.Text = "Compatibility fix";
			checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox_unwrapFolderLegacy
			// 
			checkBox_unwrapFolderLegacy.AutoSize = true;
			checkBox_unwrapFolderLegacy.Enabled = false;
			checkBox_unwrapFolderLegacy.Location = new Point(21, 83);
			checkBox_unwrapFolderLegacy.Name = "checkBox_unwrapFolderLegacy";
			checkBox_unwrapFolderLegacy.Size = new Size(152, 19);
			checkBox_unwrapFolderLegacy.TabIndex = 2;
			checkBox_unwrapFolderLegacy.Text = "Unwrap folders on copy";
			toolTip1.SetToolTip(checkBox_unwrapFolderLegacy, "[BUGGY AND SLOW!!!!]\r\nKept only for legacy purposes.\r\nI do not recommend enabling this");
			checkBox_unwrapFolderLegacy.UseVisualStyleBackColor = true;
			checkBox_unwrapFolderLegacy.CheckedChanged += checkBox_unwrapFolderLegacy_CheckedChanged;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Location = new Point(9, 31);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new Size(211, 19);
			checkBox2.TabIndex = 1;
			checkBox2.Text = "Preview media files on double click";
			checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(9, 6);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(168, 19);
			checkBox1.TabIndex = 0;
			checkBox1.Text = "Keep file modification date";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			checkBox5.AutoSize = true;
			checkBox5.Location = new Point(279, 31);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new Size(154, 19);
			checkBox5.TabIndex = 4;
			checkBox5.Text = "Fast compatibility mode";
			checkBox5.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tab_behaviour);
			tabControl1.Controls.Add(tab_appearance);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(456, 310);
			tabControl1.TabIndex = 0;
			// 
			// tab_appearance
			// 
			tab_appearance.Controls.Add(checkBox3);
			tab_appearance.Controls.Add(checkBox_showTwoProgressBars);
			tab_appearance.Controls.Add(label4);
			tab_appearance.Controls.Add(checkBox_darkMode);
			tab_appearance.Controls.Add(panel2);
			tab_appearance.Controls.Add(label2);
			tab_appearance.Controls.Add(panel1);
			tab_appearance.Controls.Add(label1);
			tab_appearance.Location = new Point(4, 24);
			tab_appearance.Name = "tab_appearance";
			tab_appearance.Padding = new Padding(3);
			tab_appearance.Size = new Size(448, 282);
			tab_appearance.TabIndex = 1;
			tab_appearance.Text = "Appearance";
			tab_appearance.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			checkBox3.AutoSize = true;
			checkBox3.Checked = true;
			checkBox3.CheckState = CheckState.Checked;
			checkBox3.Location = new Point(154, 101);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new Size(168, 19);
			checkBox3.TabIndex = 7;
			checkBox3.Text = "Show Android back button";
			toolTip1.SetToolTip(checkBox3, "Shows back button on the android side alongside path.\r\nAlternative to the default way of double clicking the header");
			checkBox3.UseVisualStyleBackColor = true;
			checkBox3.CheckedChanged += checkBox3_CheckedChanged;
			// 
			// checkBox_showTwoProgressBars
			// 
			checkBox_showTwoProgressBars.AutoSize = true;
			checkBox_showTwoProgressBars.Checked = true;
			checkBox_showTwoProgressBars.CheckState = CheckState.Checked;
			checkBox_showTwoProgressBars.Location = new Point(154, 76);
			checkBox_showTwoProgressBars.Name = "checkBox_showTwoProgressBars";
			checkBox_showTwoProgressBars.Size = new Size(180, 19);
			checkBox_showTwoProgressBars.TabIndex = 6;
			checkBox_showTwoProgressBars.Text = "Show two copy progress bars";
			toolTip1.SetToolTip(checkBox_showTwoProgressBars, "When copying more than 1 file, two progress bars will be shown.\r\nOne for total progress and one for current file progress.\r\n\r\nIf unchecked, only total progress will be shown.");
			checkBox_showTwoProgressBars.UseVisualStyleBackColor = true;
			checkBox_showTwoProgressBars.CheckedChanged += checkBox_showTwoProgressBars_CheckedChanged;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 7F);
			label4.Location = new Point(171, 45);
			label4.Name = "label4";
			label4.Size = new Size(186, 24);
			label4.TabIndex = 5;
			label4.Text = "Note: PC File Explorer will only be in dark \r\nif Windows itself has dark mode enabled";
			// 
			// checkBox_darkMode
			// 
			checkBox_darkMode.AutoSize = true;
			checkBox_darkMode.Location = new Point(154, 25);
			checkBox_darkMode.Name = "checkBox_darkMode";
			checkBox_darkMode.Size = new Size(121, 19);
			checkBox_darkMode.TabIndex = 4;
			checkBox_darkMode.Text = "Enable dark mode";
			checkBox_darkMode.UseVisualStyleBackColor = true;
			checkBox_darkMode.CheckedChanged += checkBox_darkMode_CheckedChanged;
			// 
			// panel2
			// 
			panel2.Controls.Add(radioButton5);
			panel2.Controls.Add(radioButton3);
			panel2.Controls.Add(radioButton4);
			panel2.Location = new Point(6, 116);
			panel2.Name = "panel2";
			panel2.Size = new Size(118, 73);
			panel2.TabIndex = 3;
			// 
			// radioButton5
			// 
			radioButton5.AutoSize = true;
			radioButton5.Location = new Point(5, 51);
			radioButton5.Name = "radioButton5";
			radioButton5.Size = new Size(105, 19);
			radioButton5.TabIndex = 2;
			radioButton5.TabStop = true;
			radioButton5.Text = "Fluent gradient";
			radioButton5.UseVisualStyleBackColor = true;
			radioButton5.CheckedChanged += radioButton_buttonStyle_CheckedChanged;
			// 
			// radioButton3
			// 
			radioButton3.AutoSize = true;
			radioButton3.Location = new Point(5, 3);
			radioButton3.Name = "radioButton3";
			radioButton3.Size = new Size(85, 19);
			radioButton3.TabIndex = 1;
			radioButton3.TabStop = true;
			radioButton3.Text = "Flat shaded";
			radioButton3.UseVisualStyleBackColor = true;
			radioButton3.CheckedChanged += radioButton_buttonStyle_CheckedChanged;
			// 
			// radioButton4
			// 
			radioButton4.AutoSize = true;
			radioButton4.Location = new Point(5, 28);
			radioButton4.Name = "radioButton4";
			radioButton4.Size = new Size(44, 19);
			radioButton4.TabIndex = 0;
			radioButton4.TabStop = true;
			radioButton4.Text = "Flat";
			radioButton4.UseVisualStyleBackColor = true;
			radioButton4.CheckedChanged += radioButton_buttonStyle_CheckedChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(9, 98);
			label2.Name = "label2";
			label2.Size = new Size(81, 15);
			label2.TabIndex = 2;
			label2.Text = "Button design";
			// 
			// panel1
			// 
			panel1.Controls.Add(radioButton2);
			panel1.Controls.Add(radioButton1);
			panel1.Location = new Point(8, 22);
			panel1.Name = "panel1";
			panel1.Size = new Size(118, 73);
			panel1.TabIndex = 1;
			// 
			// radioButton2
			// 
			radioButton2.AutoSize = true;
			radioButton2.Location = new Point(3, 28);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new Size(89, 19);
			radioButton2.TabIndex = 1;
			radioButton2.TabStop = true;
			radioButton2.Text = "Windows 11";
			radioButton2.UseVisualStyleBackColor = true;
			radioButton2.CheckedChanged += radioButton_iconStyle_CheckedChanged;
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Location = new Point(3, 3);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new Size(102, 19);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "Windows Aero";
			radioButton1.UseVisualStyleBackColor = true;
			radioButton1.CheckedChanged += radioButton_iconStyle_CheckedChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(11, 4);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 0;
			label1.Text = "Icon style";
			// 
			// SettingsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(456, 310);
			Controls.Add(tabControl1);
			Name = "SettingsForm";
			Text = "SettingsForm";
			FormClosing += SettingsForm_FormClosing;
			tab_behaviour.ResumeLayout(false);
			tab_behaviour.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackBar_progressWait).EndInit();
			tabControl1.ResumeLayout(false);
			tab_appearance.ResumeLayout(false);
			tab_appearance.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl1;
		private TabPage tab_behaviour;
		private TabPage tab_appearance;
		private CheckBox checkBox1;
		private CheckBox checkBox6;
		private CheckBox checkBox5;
		private CheckBox checkBox4;
		private CheckBox checkBox_unwrapFolderLegacy;
		private CheckBox checkBox2;
		private Label label1;
		private Panel panel1;
		private RadioButton radioButton2;
		private RadioButton radioButton1;
		private Panel panel2;
		private RadioButton radioButton5;
		private RadioButton radioButton3;
		private RadioButton radioButton4;
		private Label label2;
		private CheckBox checkBox_darkMode;
		private Label label3;
		private Label label_language;
		private ComboBox comboBox_lang;
		private CheckBox checkBox_useLegacyCopy;
		private ToolTip toolTip1;
		private Label label4;
		private CheckBox checkBox_showTwoProgressBars;
		private Label label5;
		private TrackBar trackBar_progressWait;
		private Label label_trackbarValue;
		private CheckBox checkBox3;
	}
}