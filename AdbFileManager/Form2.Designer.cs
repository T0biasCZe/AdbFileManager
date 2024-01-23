namespace AdbFileManager {
	partial class Form2 {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			progressBar1 = new ProgressBar();
			pictureBox1 = new PictureBox();
			filename = new RichTextBox();
			fromto = new RichTextBox();
			progress = new RichTextBox();
			timer1 = new System.Windows.Forms.Timer(components);
			label_freezewarn = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(16, 100);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(360, 16);
			progressBar1.TabIndex = 2;
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = SystemColors.Control;
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(16, -8);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(352, 64);
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			// 
			// filename
			// 
			filename.BackColor = SystemColors.Control;
			filename.BorderStyle = BorderStyle.None;
			filename.Location = new Point(16, 56);
			filename.Name = "filename";
			filename.Size = new Size(360, 16);
			filename.TabIndex = 5;
			filename.Text = "";
			// 
			// fromto
			// 
			fromto.BackColor = SystemColors.Control;
			fromto.BorderStyle = BorderStyle.None;
			fromto.Location = new Point(16, 76);
			fromto.Name = "fromto";
			fromto.Size = new Size(360, 16);
			fromto.TabIndex = 6;
			fromto.Text = "";
			// 
			// progress
			// 
			progress.BackColor = SystemColors.Control;
			progress.BorderStyle = BorderStyle.None;
			progress.Location = new Point(16, 120);
			progress.Name = "progress";
			progress.Size = new Size(113, 16);
			progress.TabIndex = 7;
			progress.Text = "";
			// 
			// timer1
			// 
			timer1.Enabled = true;
			timer1.Tick += timer1_Tick;
			// 
			// label_freezewarn
			// 
			label_freezewarn.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
			label_freezewarn.ForeColor = SystemColors.ControlDarkDark;
			label_freezewarn.Location = new Point(144, 114);
			label_freezewarn.Name = "label_freezewarn";
			label_freezewarn.Size = new Size(240, 22);
			label_freezewarn.TabIndex = 8;
			label_freezewarn.Text = "Freeze warn";
			label_freezewarn.TextAlign = ContentAlignment.TopRight;
			// 
			// Form2
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(394, 139);
			Controls.Add(progress);
			Controls.Add(fromto);
			Controls.Add(filename);
			Controls.Add(pictureBox1);
			Controls.Add(progressBar1);
			Controls.Add(label_freezewarn);
			Name = "Form2";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Copying...";
			FormClosed += Form2_FormClosed;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private ProgressBar progressBar1;
		private PictureBox pictureBox1;
		private RichTextBox filename;
		private RichTextBox fromto;
		private RichTextBox progress;
		private System.Windows.Forms.Timer timer1;
		private Label label_freezewarn;
	}
}