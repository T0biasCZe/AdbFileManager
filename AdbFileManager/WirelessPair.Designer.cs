namespace AdbFileManager {
	partial class WirelessPair {
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
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			button_pair = new Button();
			textBox3 = new TextBox();
			button_reconnect = new Button();
			helpProvider1 = new HelpProvider();
			toolTip1 = new ToolTip(components);
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 12);
			textBox1.Name = "textBox1";
			textBox1.PlaceholderText = "Device's IP Address";
			textBox1.Size = new Size(157, 23);
			textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(175, 12);
			textBox2.Name = "textBox2";
			textBox2.PlaceholderText = "Port";
			textBox2.Size = new Size(52, 23);
			textBox2.TabIndex = 2;
			// 
			// button_pair
			// 
			helpProvider1.SetHelpString(button_pair, "If this is the first time connecting the device to this PC over wireless connection, click this button to pair it.");
			button_pair.Location = new Point(175, 41);
			button_pair.Name = "button_pair";
			helpProvider1.SetShowHelp(button_pair, true);
			button_pair.Size = new Size(52, 23);
			button_pair.TabIndex = 3;
			button_pair.Text = "Pair";
			button_pair.UseVisualStyleBackColor = true;
			button_pair.Click += button1_Click;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(92, 41);
			textBox3.Name = "textBox3";
			textBox3.PlaceholderText = "Pairing code";
			textBox3.Size = new Size(77, 23);
			textBox3.TabIndex = 4;
			// 
			// button_reconnect
			// 
			helpProvider1.SetHelpString(button_reconnect, "If the phone was already paired in the past, click this button to just connect again");
			button_reconnect.Location = new Point(12, 40);
			button_reconnect.Name = "button_reconnect";
			helpProvider1.SetShowHelp(button_reconnect, true);
			button_reconnect.Size = new Size(74, 23);
			button_reconnect.TabIndex = 5;
			button_reconnect.Text = "Reconnect";
			button_reconnect.UseVisualStyleBackColor = true;
			button_reconnect.Click += button_reconnect_Click;
			// 
			// WirelessPair
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(234, 71);
			Controls.Add(button_reconnect);
			Controls.Add(textBox3);
			Controls.Add(button_pair);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			HelpButton = true;
			MaximizeBox = false;
			MaximumSize = new Size(250, 109);
			MinimizeBox = false;
			MinimumSize = new Size(250, 109);
			Name = "WirelessPair";
			Text = "WirelessPair";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private TextBox textBox2;
		private Button button_pair;
		private TextBox textBox3;
		private Button button_reconnect;
		private HelpProvider helpProvider1;
		private ToolTip toolTip1;
	}
}