namespace AdbFileManager {
	partial class ProgressBarMarquee {
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
			progressBar1 = new ProgressBar();
			button1 = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(12, 46);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(282, 26);
			progressBar1.Style = ProgressBarStyle.Continuous;
			progressBar1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Location = new Point(105, 78);
			button1.Name = "button1";
			button1.Size = new Size(96, 32);
			button1.TabIndex = 1;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label1
			// 
			label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(0, 9);
			label1.Name = "label1";
			label1.Size = new Size(304, 39);
			label1.TabIndex = 2;
			label1.Text = "label1";
			label1.TextAlign = ContentAlignment.TopCenter;
			// 
			// ProgressBarMarquee
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(306, 112);
			Controls.Add(button1);
			Controls.Add(progressBar1);
			Controls.Add(label1);
			Name = "ProgressBarMarquee";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "ProgressBarMarquee";
			ResumeLayout(false);
		}

		#endregion
		private Button button1;
		private Label label1;
		public ProgressBar progressBar1;
	}
}