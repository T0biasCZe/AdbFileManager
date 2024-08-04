namespace AdbFileManager {
	partial class UnlockForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnlockForm));
			pictureBox1 = new PictureBox();
			textBox1 = new TextBox();
			richTextBox1 = new RichTextBox();
			keypad1 = new keypad();
			richTextBox2 = new RichTextBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Image = Properties.Resources.lockedShadow;
			pictureBox1.Location = new Point(8, 8);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(120, 122);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(120, 8);
			textBox1.Name = "textBox1";
			textBox1.PlaceholderText = "Password here";
			textBox1.Size = new Size(88, 23);
			textBox1.TabIndex = 2;
			// 
			// richTextBox1
			// 
			richTextBox1.BackColor = SystemColors.Control;
			richTextBox1.BorderStyle = BorderStyle.None;
			richTextBox1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 238);
			richTextBox1.Location = new Point(216, 8);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(176, 128);
			richTextBox1.TabIndex = 14;
			richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// keypad1
			// 
			keypad1.Location = new Point(127, 32);
			keypad1.Name = "keypad1";
			keypad1.Size = new Size(74, 97);
			keypad1.TabIndex = 15;
			keypad1.OkClick += keypad1_OkClick;
			keypad1.NumberClick += keypad1_NumberClick;
			// 
			// richTextBox2
			// 
			richTextBox2.BackColor = SystemColors.Control;
			richTextBox2.BorderStyle = BorderStyle.None;
			richTextBox2.Location = new Point(8, 136);
			richTextBox2.Name = "richTextBox2";
			richTextBox2.Size = new Size(384, 40);
			richTextBox2.TabIndex = 16;
			richTextBox2.Text = "";
			// 
			// UnlockForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(393, 178);
			Controls.Add(richTextBox2);
			Controls.Add(keypad1);
			Controls.Add(richTextBox1);
			Controls.Add(textBox1);
			Controls.Add(pictureBox1);
			Name = "UnlockForm";
			Text = "UnlockForm";
			Load += UnlockForm_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBox1;
		private TextBox textBox1;
		private RichTextBox richTextBox1;
		private keypad keypad1;
		private RichTextBox richTextBox2;
	}
}