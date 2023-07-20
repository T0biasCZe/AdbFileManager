//ADB File Manager
//Originally created by T0biasCZe in 2023
//You can use this program comercially, just dont redistribute it without my permission
//If you fork thís, please give me credit

using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using Microsoft.WindowsAPICodePack.Shell;
using System.Diagnostics;

namespace AdbFileManager {
  public partial class Form1 : Form {
    public static Form1 _Form1;
    public string directoryPath = "/sdcard/";
    public Form1() {
      _Form1 = this;
      InitializeComponent();
      verticalLabel1.SendToBack();
      dataGridView1.RowHeadersWidth = 4;
      dataGridView1.DataSource = Functions.getDir(directoryPath);
      dataGridView1.Columns[0].Width = 307;
      dataGridView1.Columns[1].Width = 100;
      dataGridView1.Columns[2].Width = 115;
    }

    public static string adb(string command) {
      Process process = new Process();
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.FileName = "cmd.exe";
      process.StartInfo.Arguments = "/c " + command;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.UseShellExecute = false;
      Cursor.Current = Cursors.WaitCursor;
      process.Start();
      string output = process.StandardOutput.ReadToEnd();
      process.WaitForExit();
      Cursor.Current = Cursors.Default;
      return output;
    }
    private void verticalLabel1_Click(object sender, EventArgs e) {
      dataGridView1.DataSource = Functions.getDir(directoryPath);
    }

    private void explorerBrowser1_Load(object sender, EventArgs e) {
      string path = Environment.ExpandEnvironmentVariables("%UserProfile%\\pictures\\");
      ShellObject tvojemama = ShellObject.FromParsingName(path);
      explorerBrowser1.Navigate(tvojemama);
    }

    private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
      if(e.RowIndex >= 0) {
        string name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        string size = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        string date = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        if(name.Contains(".")) {
          MessageBox.Show("File: " + name + "\nSize: " + size + "\nDate: " + date);
        }
        else {
          directoryPath = directoryPath + name + "/";
          cur_path.Text = directoryPath;
          //MessageBox.Show(directoryPath);
          dataGridView1.DataSource = Functions.getDir(directoryPath);
        }
      }
    }

    private void android2pc_Click(object sender, EventArgs e) {
      string destinationFolder = ShellObject.FromParsingName(explorerBrowser1.NavigationLog.CurrentLocation.ParsingName).Properties.System.ItemPathDisplay.Value;
      //MessageBox.Show(destinationFolder);
      int filecount = dataGridView1.SelectedRows.Count;
      int copied = 0;
      Form2 progressbar = new Form2();
      progressbar.Show();
      foreach(DataGridViewRow row in dataGridView1.SelectedRows) {
        //MessageBox.Show(Text = Convert.ToString(row.Cells[0].Value));
        string sourceFileName = Convert.ToString(row.Cells[0].Value);
        progressbar.update(copied, filecount, directoryPath, destinationFolder, Convert.ToString(row.Cells[0].Value));
        string sourcePath = directoryPath + sourceFileName;
        string command = $"adb pull \"{sourcePath}\" \"{destinationFolder.Replace('\\', '/')}\"";
        adb(command);
        //MessageBox.Show(output);
        copied++;
      }
      progressbar.Close();

      //string sourceFileName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

    }

    private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
      if(directoryPath.EndsWith("/")) {
        int length = directoryPath.Length - 1;
        int lastIndex = directoryPath.Substring(0, length - 1).LastIndexOf("/");
        // Check if current directory is already root ("/")
        if(lastIndex < 0) return;

        directoryPath = directoryPath.Substring(0, lastIndex + 1);
      }
      else {
        int lastIndex = directoryPath.LastIndexOf("/");
        // Check if current directory is already root ("/")
        if(lastIndex < 0) return;

        directoryPath = directoryPath.Substring(0, lastIndex + 1);
      }
      cur_path.Text = directoryPath;
      dataGridView1.DataSource = Functions.getDir(directoryPath);
    }

    private void timer1_Tick(object sender, EventArgs e) {

      dataGridView1.DataSource = Functions.getDir(directoryPath);
      cur_path.Text = directoryPath;
      timer1.Stop();
      timer1.Enabled = false;
    }

    private void pc2android_Click(object sender, EventArgs e) {
      var items = explorerBrowser1.SelectedItems.ToArray();

      foreach(ShellObject item in items) {
        string sourcefile = item.ParsingName;
        string command = $"adb push \"{sourcefile}\" \"{directoryPath.Replace('\\', '/')}\"";
        adb(command);
      }
    }

    private void cur_path_TextChanged(object sender, EventArgs e) {
      directoryPath = cur_path.Text;
      dataGridView1.DataSource = Functions.getDir(directoryPath);
    }
  }
  public static class Functions {
    public static DataTable getDir(string directoryPath) {
      // Retrieve a list of files in the specified directory
      string command = "adb shell ls -lL " + directoryPath;
      string output = Form1.adb(command);
      string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
      string[] filteredLines = lines.SkipWhile(line => line == "* daemon not running; starting now at tcp:5037" ||
                                                       line == "* daemon started successfully" ||
                                                       line.StartsWith("total ")).ToArray();
      string filteredOutput = string.Join(Environment.NewLine, filteredLines);
      Console.WriteLine(filteredOutput);
      Cursor.Current = Cursors.Default;

      List<string[]> fileList = new List<string[]>();
      //AdbClient Client = new AdbClient();
      try {
        //var device = Client.GetDevices().First();
        //var receiver = new ConsoleOutputReceiver();

        //Client.ExecuteRemoteCommand("ls -l " + directoryPath, device, receiver);
        string[] files = filteredOutput.ToString().Split('\n');
        var dgv = new DataTable();
        /*dgv.Columns.Add("Permissions");
        dgv.Columns.Add("Links");
        dgv.Columns.Add("Owner");
        dgv.Columns.Add("Group");
        dgv.Columns.Add("Size");
        dgv.Columns.Add("Date");
        dgv.Columns.Add("Name");*/
        dgv.Columns.Add("Name (double click here to go up)");
        dgv.Columns.Add("Size (KiB)", typeof(decimal));
        dgv.Columns.Add("Date", typeof(DateTime));

        foreach(string file in files.Skip(1)) {
          try {
            if(!string.IsNullOrWhiteSpace(file)) {
              /* line examples
              "drwx------ 9 u0_a201  u0_a201     8192 2023-06-17 13:26 Music"
               "-rw------- 1 u0_a201  u0_a201  1331648 2021-11-22 00:42 SpaceCadetPinball.cia"
               "-rw------- 1 u0_a201  u0_a201  1365560 2021-01-19 04:14 Not\ Funny,\ Didn't\ HahahÃ¦.webm"*/
              string[] attributes = CustomSplit(file, ' ');
              Form1._Form1.textBox3.Text = attributes.ToString();
              string permissions = attributes[0];
              int links = int.Parse(attributes[1]);
              string owner = attributes[2];
              string group = attributes[3];
              decimal size = decimal.Round(decimal.Parse(attributes[4]) / 1024, 3);

              DateTime date = DateTime.Parse(attributes[5] + " " + attributes[6]);
              string name = string.Join(' ', attributes.Skip(7));

              //dgv.Rows.Add(permissions, links, owner, group, size, date, name);
              dgv.Rows.Add(name, size, date);
            }
          }
          catch(Exception ex) {
            Console.WriteLine(ex.ToString());
          }
        }
        if(dgv.Rows.Count == 0) {
          dgv.Rows.Add("No files found", 0, DateTime.UnixEpoch);
        }
        else if(dgv.Rows.Count > 18) {
          Form1._Form1.dataGridView1.Columns[0].Width = 290;
        }
        else Form1._Form1.dataGridView1.Columns[0].Width = 307;
        return dgv;
      }
      catch(Exception ex) {
        var dgv = new DataTable();
        dgv.Columns.Add("Name (double click here to go up)");
        dgv.Columns.Add("Size");
        dgv.Columns.Add("Date");
        dgv.Rows.Add("No device found", 0, DateTime.UnixEpoch);
        dgv.Rows.Add(ex, 0, DateTime.UnixEpoch);
        return dgv;

      }
    }
    public static string[] CustomSplit(string text, char delimiter) {
      string[] result = Regex.Split(text, $"(?<!\\\\){delimiter}+");

      for(int i = 0; i < result.Length; i++) {
        result[i] = result[i].Replace("\\ ", " ");
      }
      //strip new line symbols from elements
      for(int i = 0; i < result.Length; i++) {
        result[i] = result[i].Replace("\r", "");
        result[i] = result[i].Replace("\n", "");
      }
      return result;
    }
  }

}