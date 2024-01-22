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
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// progressBar1
			// 
			resources.ApplyResources(progressBar1, "progressBar1");
			progressBar1.Name = "progressBar1";
			// 
			// pictureBox1
			// 
			resources.ApplyResources(pictureBox1, "pictureBox1");
			pictureBox1.BackColor = SystemColors.Control;
			pictureBox1.Name = "pictureBox1";
			pictureBox1.TabStop = false;
			// 
			// filename
			// 
			resources.ApplyResources(filename, "filename");
			filename.BackColor = SystemColors.Control;
			filename.BorderStyle = BorderStyle.None;
			filename.Name = "filename";
			// 
			// fromto
			// 
			resources.ApplyResources(fromto, "fromto");
			fromto.BackColor = SystemColors.Control;
			fromto.BorderStyle = BorderStyle.None;
			fromto.Name = "fromto";
			// 
			// progress
			// 
			resources.ApplyResources(progress, "progress");
			progress.BackColor = SystemColors.Control;
			progress.BorderStyle = BorderStyle.None;
			progress.Name = "progress";
			// 
			// timer1
			// 
			timer1.Enabled = true;
			timer1.Tick += timer1_Tick;
			// 
			// label1
			// 
			resources.ApplyResources(label1, "label1");
			label1.ForeColor = SystemColors.ControlDarkDark;
			label1.Name = "label1";
			// 
			// Form2
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(progress);
			Controls.Add(fromto);
			Controls.Add(filename);
			Controls.Add(pictureBox1);
			Controls.Add(progressBar1);
			Controls.Add(label1);
			Name = "Form2";
			FormClosed += Form2_FormClosed;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ProgressBar progressBar1;
    private PictureBox pictureBox1;
    private RichTextBox filename;
    private RichTextBox fromto;
    private RichTextBox progress;
    private System.Windows.Forms.Timer timer1;
		private Label label1;
	}
}