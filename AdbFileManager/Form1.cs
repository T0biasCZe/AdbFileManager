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
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using System.Text;
using System.Globalization;

namespace AdbFileManager {
	public partial class Form1 : Form {
		public static Form1 _Form1;
		public string directoryPath = "/sdcard/";
		public string tempPath = Path.GetTempPath() + "adbfilemanager\\";
		public bool temp_folder_created = false;
		public Form1() {
			_Form1 = this;
			Functions.set_language();
			InitializeComponent();		


			this.Controls.Add(panel2);
			panel1.Controls.Remove(panel2);
			panel2.BringToFront();
			verticalLabel1.SendToBack();
			dataGridView1.RowHeadersWidth = 4;
			Console.WriteLine("datagrid virtual mode: " + dataGridView1.VirtualMode);
			dataGridView1.VirtualMode = false;
			dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);

			DataGridViewImageColumn img = (DataGridViewImageColumn)dataGridView1.Columns[0];
			img.ImageLayout = DataGridViewImageCellLayout.Zoom;
			dataGridView1.Columns[0].Width = 25;
			dataGridView1.Columns[1].Width = 307;
			dataGridView1.Columns[2].Width = 80;
			dataGridView1.Columns[3].Width = 115;

			//set Console app codepage to UTF-8.
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.WindowHeight = 20;
			var handle = GetConsoleWindow();
			ShowWindow(handle, SW_HIDE);
			string versionn = $"{AdbFileManager.Properties.Resources.CurrentCommit.Trim()}  18.12.23";
			version.Text = versionn;
			Console.WriteLine(versionn);
		}

		public static string adb(string command) {
			Process process = new Process();
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c chcp 65001";
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			Cursor.Current = Cursors.WaitCursor;
			process.Start();

			process.StartInfo.Arguments = "/c " + command;
			process.Start();
			string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			Cursor.Current = Cursors.Default;
			return output;
		}
		private void verticalLabel1_Click(object sender, EventArgs e) {
			dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);
		}

		private void explorerBrowser1_Load(object sender, EventArgs e) {
			try {
				string path = Environment.ExpandEnvironmentVariables("%UserProfile%\\pictures\\");
				ShellObject Shell = ShellObject.FromParsingName(path);
				explorerBrowser1.Navigate(Shell);
				explorer_path.Text = path;
			}
			catch {
				string path = Environment.ExpandEnvironmentVariables("C:\\");
				ShellObject Shell = ShellObject.FromParsingName(path);
				explorerBrowser1.Navigate(Shell);
				explorer_path.Text = path;
			}
		}

		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			if(e.RowIndex >= 0) {
				string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
				string size = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
				string date = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
				string permissions = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
				if(!Functions.isFolder(permissions)) {
					if(checkBox_preview.Checked) {
						if(Functions.videoExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase)) || Functions.imageExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase)) || Functions.audioExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) {
							//copy file to temp folder
							string sourcePath = directoryPath + name;
							string destinationPath = tempPath + name;

							if(!temp_folder_created) {
								Directory.CreateDirectory(tempPath);
								temp_folder_created = true	;
							}
							string command = $"adb pull \"{sourcePath}\" \"{destinationPath}\"";
							Process process = new Process();
							process.StartInfo.FileName = "cmd.exe";
							process.StartInfo.Arguments = "/c " + command;
							process.Start();

							var handle = GetConsoleWindow();
							ShowWindow(handle, SW_SHOW);
							process.WaitForExit();

							Process file_opener = new Process();
							file_opener.StartInfo.FileName = "explorer.exe";
							file_opener.StartInfo.Arguments = "\"" + destinationPath + "\"";
							file_opener.Start();

							ShowWindow(handle, console_shown ? 5 : 0);
						}

					}
					else MessageBox.Show("File: " + name + "\nSize: " + size + "\nDate: " + date);
					
				}
				else {
					directoryPath = directoryPath + name + "/";
					cur_path.Text = directoryPath;
					//MessageBox.Show(directoryPath);
					dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);
				}
			}
		}
		private int ParseProgress(string line) {
			// Assuming the progress is represented as a percentage in the output line
			// and it's always at the start of the line in the format of "[x%]"
			int startIndex = line.IndexOf('[');
			int endIndex = line.IndexOf(']');
			if(startIndex != -1 && endIndex != -1 && endIndex > startIndex) {
				string progressString = line.Substring(startIndex + 1, endIndex - startIndex - 1).TrimEnd('%');
				if(int.TryParse(progressString, out int progress)) {
					return progress;
				}
			}

			// Return -1 if the progress could not be parsed
			return -1;
		}
		bool copying = false;
		private void android2pc_Click(object sender, EventArgs e) {
			string destinationFolder = ShellObject.FromParsingName(explorerBrowser1.NavigationLog.CurrentLocation.ParsingName).Properties.System.ItemPathDisplay.Value;
			//MessageBox.Show(destinationFolder);
			int filecount = dataGridView1.SelectedRows.Count;
			int copied = 0;
			Form2 progressbar = new Form2();
			progressbar.Show();
			//try to make the progressbar get shown
			progressbar.BringToFront();
			progressbar.Activate();
			progressbar.Focus();

			copying = true;
			string date = checkBox_filedate.Checked ? " -a " : "";
			List<File> files = new List<File>();
			foreach(DataGridViewRow row in dataGridView1.SelectedRows) {
				//put each selected file into a list
				string name = row.Cells[1].Value.ToString();
				string size = row.Cells[2].Value.ToString();
				string datee = row.Cells[3].Value.ToString();
				string permissions = row.Cells[4].Value.ToString();
				bool isDirectory = Functions.isFolder(permissions);
				files.Add(new File(name, size, datee, permissions, isDirectory));
			}

			progressbar.Close();
			copying = false;

			//string sourceFileName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

		}

		private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			goUpDirectory();
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e) {
			Console.WriteLine("Key pressed: " + e.KeyValue);
			if(e.KeyCode == Keys.Enter) {
				clickedFolder();
			}
			else if(e.KeyCode == Keys.Back) {
				goUpDirectory();
			}
		}
		void clickedFolder() {
			int rowIndex = dataGridView1.CurrentCell.RowIndex;
			if(rowIndex >= 0) {
				string name = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
				string size = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
				string date = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
				if(name.Contains(".")) {
					MessageBox.Show("File: " + name + "\nSize: " + size + "\nDate: " + date);
				}
				else {
					directoryPath = directoryPath + name + "/";
					cur_path.Text = directoryPath;
					//MessageBox.Show(directoryPath);
					dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);
				}
			}
		}

		void goUpDirectory() {
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
			dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);
		}
		private void timer1_Tick(object sender, EventArgs e) {

			dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);
			cur_path.Text = directoryPath;
			timer1.Stop();
			timer1.Enabled = false;
		}

		private void pc2android_Click(object sender, EventArgs e) {
			var items = explorerBrowser1.SelectedItems.ToArray();
			string date = checkBox_filedate.Checked ? " -a " : "";
			int filecount = items.Count();
			int copied = 0;
			Form2 progressbar = new Form2();
			progressbar.Show();
			//try to make the progressbar get shown
			progressbar.BringToFront();
			progressbar.Activate();
			progressbar.Focus();
			copying = true;
			foreach(ShellObject item in items) {
				string sourcefile = item.ParsingName;
				string command = $"adb push {date} \"{sourcefile}\" \"{directoryPath.Replace('\\', '/')}\"";
				Console.WriteLine(command);
				progressbar.update(copied, filecount, explorer_path.Text, directoryPath, sourcefile);
				Console.WriteLine(adb(command));
				copied++;
			}
			progressbar.Close();
			copying = false;
		}

		private void cur_path_TextChanged(object sender, EventArgs e) {
			directoryPath = cur_path.Text;
			dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);
		}

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void explorerBrowser1_NavigationComplete(object sender, Microsoft.WindowsAPICodePack.Controls.NavigationCompleteEventArgs e) {

			//set textbox "explorer_path" to current explorerBrowser1 path
			string currentPath = ShellObject.FromParsingName(explorerBrowser1.NavigationLog.CurrentLocation.ParsingName).Properties.System.ItemPathDisplay.Value;
			explorer_path.Text = currentPath;
		}

		private void explorer_path_TextChanged(object sender, EventArgs e) {
		}

		private void explorer_path_KeyPress(object sender, KeyPressEventArgs e) {
			//check if enter key was pressed
			if(e.KeyChar == (char)13) {
				string oldPath = ShellObject.FromParsingName(explorerBrowser1.NavigationLog.CurrentLocation.ParsingName).Properties.System.ItemPathDisplay.Value;
				try {
					ShellObject Shell = ShellObject.FromParsingName(explorer_path.Text);
					explorerBrowser1.Navigate(Shell);
				}
				catch {
					MessageBox.Show("Invalid path", "Error okurek 🥒", MessageBoxButtons.OK, MessageBoxIcon.Error);
					explorer_path.Text = oldPath;
				}
			}
		}

		private void version_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start("explorer.exe", "https://github.com/T0biasCZe/AdbFileManager");
		}
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		bool console_shown = false;
		private void button1_Click(object sender, EventArgs e) {
			console_shown = !console_shown;
			var handle = GetConsoleWindow();
			if(console_shown) {
				ShowWindow(handle, SW_SHOW);
			}
			else {
				ShowWindow(handle, SW_HIDE);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			//kill the process adb.exe if it's running
			Process[] adb = Process.GetProcessesByName("adb.exe");
			foreach(Process process in adb) {
				process.Kill();
			}
			adb = Process.GetProcessesByName("adb");
			foreach(Process process in adb) {
				process.Kill();
			}

			if(Directory.Exists(tempPath)) {
				Directory.Delete(tempPath, true);
			}
		}
	}

	public static class Functions {
		public static string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".webp", ".heif", ".mpo" };
		public static string[] videoExtensions = { ".mp4", ".mkv", ".webm", ".avi", ".mov", ".wmv", ".flv", ".3gp", ".m4v", ".mpg", ".mpeg", ".m2v", ".m4v", ".m2ts", ".mts", ".ts", ".vob", ".divx", ".xvid" };
		public static string[] romExtensions = { ".nes", ".snes", ".gba", ".gbc", ".gb", ".nds", ".n64", ".psx", ".iso", ".cia", ".3ds", ".3dsx", ".wbfs", ".rvz" };
		public static string[] audioExtensions = { ".mp3", ".wav", ".ogg", ".flac", ".m4a", ".aac", ".wma", ".mod", ".mid", ".s3m", ".midi" };
		public static string[] documentExtensions = { ".docx", ".pdf", ".txt", ".pptx", ".xlsx", ".odt", ".rtf" };
		public static string[] archiveExtensions = { ".zip", ".rar", ".7z", ".tar", ".gz", ".bz2", ".xz" };
		public static string[] executableExtensions = { ".exe", ".dll", ".bat", ".msi", ".jar", ".py", ".sh", ".apk" };

		public static bool isFolder(string path) {
			/*//i said do not look :(
			//folders have these filesize values
			if(path.Contains("3452")) return true;
			if(path.Contains("4096")) return true;
			else if(path.Contains("512000")) return true;
			else if(path.Contains("24576")) return true;
			else if(path.Contains("8192")) return true;
			else if(path.Contains("53248")) return true;
			else if(path.Contains("122880")) return true;
			else if(path.Contains("20480")) return true;
			else return false;*/
			if(path[0] == 'd') return true; //the first character of the line is 'd' if it's a directory
			else return false;
		}

		public static DataTable getDir(string directoryPath, bool old_android) {
			// Retrieve a list of files in the specified directory
			string command = old_android ? $"adb shell ls -lL {directoryPath}" : $"adb shell ls -l {directoryPath}";
			Console.WriteLine(command);
			string output = Form1.adb(command);
			string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			/*string[] filteredLines = lines.SkipWhile(line => line == "* daemon not running; starting now at tcp:5037" ||
															 line == "* daemon started successfully" ||
															 line.StartsWith("total ")).ToArray();*/
			string filteredOutput = string.Join(Environment.NewLine, lines);
			Console.WriteLine(filteredOutput);
			Cursor.Current = Cursors.Default;

			List<string[]> fileList = new List<string[]>();
			try {
				string[] files = filteredOutput.ToString().Split('\n');
				var dgv = new DataTable();

				dgv.Columns.Add("ico", typeof(Icon));
				dgv.Columns.Add("Name (double click here to go up)");
				dgv.Columns.Add("Size (KiB)", typeof(decimal));
				dgv.Columns.Add("Date", typeof(DateTime));
				dgv.Columns.Add("Attr");

				foreach(string filee in files.Skip(1)) {
					string file = filee.Trim();
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
							Icon icon;
							try {
								if(isFolder(permissions)) {
									if(file.Contains("dcim", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_image;
									else if(file.EndsWith(@"download", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_downloads;
									else if(file.EndsWith(@"music", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(file.EndsWith(@"movies", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_video;
									else if(file.EndsWith(@"documents", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_document;
									else if(file.EndsWith(@"ringtones", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(file.EndsWith(@"alarms", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(file.EndsWith(@"notifications", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(file.EndsWith(@"podcasts", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else icon = Icons.folder_image;
								}

								else if(imageExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.image2;
								else if(videoExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.video2;
								else if(romExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.rom;
								else if(audioExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.music2;
								else if(documentExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.doc2;
								else if(archiveExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.archive;
								else if(executableExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.archive;
								else icon = Icons.file;
							}
							catch(Exception ex) {
								ConsoleColor old = Console.ForegroundColor;
								Console.ForegroundColor = ConsoleColor.Magenta;
								Console.WriteLine("Catched exception while parsing file icon: ");
								Console.WriteLine(ex.ToString());
								Console.ForegroundColor = old;
								//use generic system icon
								icon = null;

							}
							//dgv.Rows.Add(permissions, links, owner, group, size, date, name);
							dgv.Rows.Add(icon, name, size, date, permissions);
						}
					}
					catch(Exception ex) {
						ConsoleColor old = Console.ForegroundColor;
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Exception occurred while parsing file list: ");
						Console.WriteLine(ex.ToString());
						Console.ForegroundColor = old;
					}
				}
				if(dgv.Rows.Count == 0) {
					dgv.Rows.Add(new Icon(@"icons\file.ico"), "No files found", 0, DateTime.UnixEpoch);
				}
				else if(dgv.Rows.Count > 18) {
					Form1._Form1.dataGridView1.Columns[1].Width = 290;
				}
				else Form1._Form1.dataGridView1.Columns[1].Width = 307;
				return dgv;
			}
			catch(Exception ex) {
				var dgv = new DataTable();
				dgv.Columns.Add("ico", typeof(Icon));
				dgv.Columns.Add("Name (double click here to go up)");
				dgv.Columns.Add("Size");
				dgv.Columns.Add("Date");
				dgv.Rows.Add(new Icon(@"icons\file.ico"), "No device found", 0, DateTime.UnixEpoch);
				dgv.Rows.Add(new Icon(@"icons\file.ico"), ex, 0, DateTime.UnixEpoch);

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

		public static void set_language() {
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");
		}
	}
	public static class Icons {
		public static Icon folder_image = new Icon(@"icons\folder_image.ico");
		public static Icon folder_downloads = new Icon(@"icons\folder_downloads.ico");
		public static Icon folder_music = new Icon(@"icons\folder_music.ico");
		public static Icon folder_video = new Icon(@"icons\folder_video.ico");
		public static Icon folder_document = new Icon(@"icons\folder_document.ico");
		public static Icon image2 = new Icon(@"icons\image2.ico");
		public static Icon video2 = new Icon(@"icons\video2.ico");
		public static Icon rom = new Icon(@"icons\rom.ico");
		public static Icon music2 = new Icon(@"icons\music2.ico");
		public static Icon doc2 = new Icon(@"icons\doc2.ico");
		public static Icon archive = new Icon(@"icons\archive.ico");
		public static Icon exe = new Icon(@"icons\exe.ico");
		public static Icon file = new Icon(@"icons\file.ico");
	}
	public class File {
		public string name;
		public string size;
		public string date;
		public string permissions;
		public bool isDirectory;
		public File(string name, string size, string date, string permissions, bool isDirectory) {
			this.name = name;
			this.size = size;
			this.date = date;
			this.permissions = permissions;
			this.isDirectory = isDirectory;
		}
	}

}
