using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdbFileManager {
    public partial class CustomError : Form {
        public CustomError(string error) {
            InitializeComponent();
            richTextBox1.Text = error;

            this.AcceptButton = button1;
            // Set the cancel button of the form to button2.
            this.CancelButton = button2;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add button1 to the form.
            this.Controls.Add(button1);
            // Add button2 to the form.
            this.Controls.Add(button2);

            // Display the form as a modal dialog box.
            this.ShowDialog();
        }
    }
}
