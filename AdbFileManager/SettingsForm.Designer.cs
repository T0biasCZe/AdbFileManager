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
			TabPage tab_behaviour;
			label_language = new Label();
			comboBox_lang = new ComboBox();
			label3 = new Label();
			checkBox6 = new CheckBox();
			checkBox4 = new CheckBox();
			checkBox3 = new CheckBox();
			checkBox2 = new CheckBox();
			checkBox1 = new CheckBox();
			checkBox5 = new CheckBox();
			tabControl1 = new TabControl();
			tab_appearance = new TabPage();
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
			tab_behaviour = new TabPage();
			tab_behaviour.SuspendLayout();
			tabControl1.SuspendLayout();
			tab_appearance.SuspendLayout();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tab_behaviour
			// 
			tab_behaviour.Controls.Add(label_language);
			tab_behaviour.Controls.Add(comboBox_lang);
			tab_behaviour.Controls.Add(label3);
			tab_behaviour.Controls.Add(checkBox6);
			tab_behaviour.Controls.Add(checkBox4);
			tab_behaviour.Controls.Add(checkBox3);
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
			// label_language
			// 
			label_language.AutoSize = true;
			label_language.Location = new Point(8, 163);
			label_language.Name = "label_language";
			label_language.Size = new Size(161, 15);
			label_language.TabIndex = 8;
			label_language.Text = "Language (BROKEN LAYOUT)";
			// 
			// comboBox_lang
			// 
			comboBox_lang.FormattingEnabled = true;
			comboBox_lang.Items.AddRange(new object[] { "English", "Čeština", "Polski", "Deutsch", "Japanese", "Espanol" });
			comboBox_lang.Location = new Point(8, 181);
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
			label3.Location = new Point(143, 210);
			label3.Name = "label3";
			label3.Size = new Size(270, 42);
			label3.TabIndex = 6;
			label3.Text = "THIS TAB IS NOT PROGRAMMED YET \r\n(except lang)";
			// 
			// checkBox6
			// 
			checkBox6.AutoSize = true;
			checkBox6.Location = new Point(8, 131);
			checkBox6.Name = "checkBox6";
			checkBox6.Size = new Size(135, 19);
			checkBox6.TabIndex = 5;
			checkBox6.Text = "Open in last location";
			checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			checkBox4.AutoSize = true;
			checkBox4.Location = new Point(8, 81);
			checkBox4.Name = "checkBox4";
			checkBox4.Size = new Size(114, 19);
			checkBox4.TabIndex = 3;
			checkBox4.Text = "Compatibility fix";
			checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			checkBox3.AutoSize = true;
			checkBox3.Location = new Point(8, 56);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new Size(152, 19);
			checkBox3.TabIndex = 2;
			checkBox3.Text = "Unwrap folders on copy";
			checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Location = new Point(8, 31);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new Size(211, 19);
			checkBox2.TabIndex = 1;
			checkBox2.Text = "Preview media files on double click";
			checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(8, 6);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(168, 19);
			checkBox1.TabIndex = 0;
			checkBox1.Text = "Keep file modification date";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			checkBox5.AutoSize = true;
			checkBox5.Location = new Point(20, 106);
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
		private CheckBox checkBox3;
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
	}
}