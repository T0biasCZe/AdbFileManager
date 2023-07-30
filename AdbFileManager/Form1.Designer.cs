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
      filedate_check = new CheckBox();
      ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
      panel1.SuspendLayout();
      SuspendLayout();
      // 
      // textBox1
      // 
      textBox1.Location = new Point(1168, 608);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(456, 23);
      textBox1.TabIndex = 1;
      // 
      // dataGridView1
      // 
      dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
      dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridView1.GridColor = Color.White;
      dataGridView1.Location = new Point(24, 40);
      dataGridView1.Name = "dataGridView1";
      dataGridView1.RowTemplate.Height = 25;
      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dataGridView1.Size = new Size(528, 472);
      dataGridView1.TabIndex = 2;
      dataGridView1.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
      dataGridView1.ColumnHeaderMouseDoubleClick += dataGridView1_ColumnHeaderMouseDoubleClick;
      // 
      // textBox2
      // 
      textBox2.Location = new Point(1168, 648);
      textBox2.Name = "textBox2";
      textBox2.Size = new Size(456, 23);
      textBox2.TabIndex = 3;
      // 
      // textBox3
      // 
      textBox3.Location = new Point(1168, 688);
      textBox3.Name = "textBox3";
      textBox3.Size = new Size(448, 23);
      textBox3.TabIndex = 6;
      // 
      // explorerBrowser1
      // 
      explorerBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      explorerBrowser1.AutoSize = true;
      explorerBrowser1.Location = new Point(616, 8);
      explorerBrowser1.Name = "explorerBrowser1";
      explorerBrowser1.PropertyBagName = "Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser";
      explorerBrowser1.Size = new Size(552, 496);
      explorerBrowser1.TabIndex = 7;
      explorerBrowser1.Load += explorerBrowser1_Load;
      // 
      // android2pc
      // 
      android2pc.Anchor = AnchorStyles.None;
      android2pc.FlatAppearance.BorderSize = 3;
      android2pc.FlatStyle = FlatStyle.Popup;
      android2pc.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      android2pc.Location = new Point(572, 168);
      android2pc.Name = "android2pc";
      android2pc.Size = new Size(32, 40);
      android2pc.TabIndex = 8;
      android2pc.Text = ">";
      android2pc.UseVisualStyleBackColor = true;
      android2pc.Click += android2pc_Click;
      // 
      // pc2android
      // 
      pc2android.Anchor = AnchorStyles.None;
      pc2android.FlatAppearance.BorderSize = 3;
      pc2android.FlatStyle = FlatStyle.Popup;
      pc2android.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      pc2android.Location = new Point(572, 216);
      pc2android.Name = "pc2android";
      pc2android.Size = new Size(32, 40);
      pc2android.TabIndex = 9;
      pc2android.Text = "<";
      pc2android.UseVisualStyleBackColor = true;
      pc2android.Click += pc2android_Click;
      // 
      // verticalLabel1
      // 
      verticalLabel1.Anchor = AnchorStyles.None;
      verticalLabel1.BackColor = SystemColors.ControlLight;
      verticalLabel1.ForeColor = SystemColors.ControlText;
      verticalLabel1.Location = new Point(580, 272);
      verticalLabel1.Name = "verticalLabel1";
      verticalLabel1.RenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
      verticalLabel1.Size = new Size(16, 72);
      verticalLabel1.TabIndex = 10;
      verticalLabel1.Text = "     Refresh";
      verticalLabel1.TextDrawMode = randz.CustomControls.DrawMode.TopBottom;
      verticalLabel1.TransparentBackground = false;
      verticalLabel1.Click += verticalLabel1_Click;
      verticalLabel1.DoubleClick += verticalLabel1_Click;
      verticalLabel1.MouseClick += verticalLabel1_Click;
      verticalLabel1.MouseDoubleClick += verticalLabel1_Click;
      // 
      // verticalLabel2
      // 
      verticalLabel2.Anchor = AnchorStyles.None;
      verticalLabel2.BackColor = Color.Gray;
      verticalLabel2.ForeColor = SystemColors.ControlText;
      verticalLabel2.Location = new Point(580, 272);
      verticalLabel2.Name = "verticalLabel2";
      verticalLabel2.RenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
      verticalLabel2.Size = new Size(18, 74);
      verticalLabel2.TabIndex = 11;
      verticalLabel2.Text = null;
      verticalLabel2.TextDrawMode = randz.CustomControls.DrawMode.TopBottom;
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
      cur_path.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      cur_path.Location = new Point(24, 16);
      cur_path.Name = "cur_path";
      cur_path.Size = new Size(528, 23);
      cur_path.TabIndex = 12;
      cur_path.TextChanged += cur_path_TextChanged;
      // 
      // panel1
      // 
      panel1.AutoSize = true;
      panel1.Controls.Add(filedate_check);
      panel1.Controls.Add(verticalLabel1);
      panel1.Controls.Add(android2pc);
      panel1.Controls.Add(pc2android);
      panel1.Controls.Add(verticalLabel2);
      panel1.Location = new Point(0, 8);
      panel1.Name = "panel1";
      panel1.Size = new Size(1176, 528);
      panel1.TabIndex = 13;
      // 
      // filedate_check
      // 
      filedate_check.AutoSize = true;
      filedate_check.Location = new Point(24, 504);
      filedate_check.Name = "filedate_check";
      filedate_check.Size = new Size(148, 19);
      filedate_check.TabIndex = 14;
      filedate_check.Text = "Keep file modified date";
      filedate_check.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1174, 536);
      Controls.Add(cur_path);
      Controls.Add(explorerBrowser1);
      Controls.Add(textBox3);
      Controls.Add(textBox2);
      Controls.Add(dataGridView1);
      Controls.Add(textBox1);
      Controls.Add(panel1);
      Icon = (Icon)resources.GetObject("$this.Icon");
      MaximumSize = new Size(1190, 2000);
      MinimumSize = new Size(1190, 0);
      Name = "Form1";
      Text = " ";
      Load += Form1_Load;
      ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private TextBox textBox1;
    private TextBox textBox2;
    public TextBox textBox3;
    private Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser explorerBrowser1;
    private Button android2pc;
    private Button pc2android;
    public DataGridView dataGridView1;
    private randz.CustomControls.VerticalLabel verticalLabel1;
    private randz.CustomControls.VerticalLabel verticalLabel2;
    private System.Windows.Forms.Timer timer1;
    private TextBox cur_path;
    private Panel panel1;
    private CheckBox filedate_check;
  }
}