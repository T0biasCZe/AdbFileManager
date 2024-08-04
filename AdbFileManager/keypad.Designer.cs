namespace AdbFileManager {
	partial class keypad {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			buttonOk = new Button();
			button0 = new Button();
			button7 = new Button();
			button8 = new Button();
			button9 = new Button();
			button4 = new Button();
			button5 = new Button();
			button6 = new Button();
			button3 = new Button();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			// 
			// buttonOk
			// 
			buttonOk.Location = new Point(49, 73);
			buttonOk.Name = "buttonOk";
			buttonOk.Size = new Size(24, 23);
			buttonOk.TabIndex = 24;
			buttonOk.Text = "✔";
			buttonOk.UseVisualStyleBackColor = true;
			// 
			// button0
			// 
			button0.Location = new Point(1, 73);
			button0.Name = "button0";
			button0.Size = new Size(48, 23);
			button0.TabIndex = 23;
			button0.Text = "0";
			button0.UseVisualStyleBackColor = true;
			button0.Click += button_number_Click;
			// 
			// button7
			// 
			button7.Location = new Point(1, 1);
			button7.Name = "button7";
			button7.Size = new Size(24, 23);
			button7.TabIndex = 22;
			button7.Text = "7";
			button7.UseVisualStyleBackColor = true;
			button7.Click += button_number_Click;
			// 
			// button8
			// 
			button8.Location = new Point(25, 1);
			button8.Name = "button8";
			button8.Size = new Size(24, 23);
			button8.TabIndex = 21;
			button8.Text = "8";
			button8.UseVisualStyleBackColor = true;
			button8.Click += button_number_Click;
			// 
			// button9
			// 
			button9.Location = new Point(49, 1);
			button9.Name = "button9";
			button9.Size = new Size(24, 23);
			button9.TabIndex = 20;
			button9.Text = "9";
			button9.UseVisualStyleBackColor = true;
			button9.Click += button_number_Click;
			// 
			// button4
			// 
			button4.Location = new Point(1, 25);
			button4.Name = "button4";
			button4.Size = new Size(24, 23);
			button4.TabIndex = 19;
			button4.Text = "4";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button_number_Click;
			// 
			// button5
			// 
			button5.Location = new Point(25, 25);
			button5.Name = "button5";
			button5.Size = new Size(24, 23);
			button5.TabIndex = 18;
			button5.Text = "5";
			button5.UseVisualStyleBackColor = true;
			button5.Click += button_number_Click;
			// 
			// button6
			// 
			button6.Location = new Point(49, 25);
			button6.Name = "button6";
			button6.Size = new Size(24, 23);
			button6.TabIndex = 17;
			button6.Text = "6";
			button6.UseVisualStyleBackColor = true;
			button6.Click += button_number_Click;
			// 
			// button3
			// 
			button3.Location = new Point(49, 49);
			button3.Name = "button3";
			button3.Size = new Size(24, 23);
			button3.TabIndex = 16;
			button3.Text = "3";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button_number_Click;
			// 
			// button1
			// 
			button1.Location = new Point(1, 49);
			button1.Name = "button1";
			button1.Size = new Size(24, 23);
			button1.TabIndex = 15;
			button1.Text = "1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button_number_Click;
			// 
			// button2
			// 
			button2.Location = new Point(25, 49);
			button2.Name = "button2";
			button2.Size = new Size(24, 23);
			button2.TabIndex = 14;
			button2.Text = "2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button_number_Click;
			// 
			// keypad
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(buttonOk);
			Controls.Add(button0);
			Controls.Add(button7);
			Controls.Add(button8);
			Controls.Add(button9);
			Controls.Add(button4);
			Controls.Add(button5);
			Controls.Add(button6);
			Controls.Add(button3);
			Controls.Add(button1);
			Controls.Add(button2);
			Name = "keypad";
			Size = new Size(74, 97);
			ResumeLayout(false);
		}

		private void Button0_Click(object sender, EventArgs e) {
			throw new NotImplementedException();
		}

		#endregion

		private Button buttonOk;
		private Button button0;
		private Button button7;
		private Button button8;
		private Button button9;
		private Button button4;
		private Button button5;
		private Button button6;
		private Button button3;
		private Button button1;
		private Button button2;
	}
}
