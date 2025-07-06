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
using Microsoft.WindowsAPICodePack.ApplicationServices;
using System.Reflection;
using System.Resources;
using Microsoft.WindowsAPICodePack.Dialogs;
using TaskDialogButton = System.Windows.Forms.TaskDialogButton;
using TaskDialog = System.Windows.Forms.TaskDialog;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;
using Microsoft.WindowsAPICodePack.Controls;
using Microsoft.Win32;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;

namespace AdbFileManager {
	public partial class Form1 : Form {
		public static Form1 _Form1;
		public string directoryPath = "/sdcard/";
		public string tempPath = Path.GetTempPath() + "adbfilemanager\\";
		public bool temp_folder_created = false;

		public static ResourceManager rm = new ResourceManager("AdbFileManager.strings", Assembly.GetExecutingAssembly());
		public Form1() {
			try {
				SettingsManager.LoadSettings();

				showConsole();
				_Form1 = this;
				applyLang();

				InitializeComponent();

				load_settings();

				UIStyle.ApplyModernTheme(this);
				if(SettingsManager.settings.DarkMode) {
					UIStyle.LoadDarkMode(this);
				}


				checkBox_android6fix.Enabled = true;

				//this.Controls.Add(panel_dolniTlacitka);
				//panel_main.Controls.Remove(panel_dolniTlacitka);
				panel_dolniTlacitka.BringToFront();
				verticalLabel_refresh.BringToFront();
				dataGridView_soubory.RowHeadersWidth = 4;
				Console.WriteLine("datagrid virtual mode: " + dataGridView_soubory.VirtualMode);
				dataGridView_soubory.VirtualMode = false;
				//dataGridView1.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked);
				DataTable blank = new DataTable();
				//add header to blank
				blank.Columns.Add("ico", typeof(Icon));
				blank.Columns.Add("Name");
				blank.Columns.Add("Size");
				blank.Columns.Add("Date");
				blank.Columns.Add("Attr");
				blank.Rows.Add(new Icon(@"icons\file.ico"), "Loading program, please wait", 0, DateTime.UnixEpoch);
				dataGridView_soubory.DataSource = blank;

				DataGridViewImageColumn img = (DataGridViewImageColumn)dataGridView_soubory.Columns[0];
				img.ImageLayout = DataGridViewImageCellLayout.Zoom;
				dataGridView_soubory.Columns[0].Width = 25;
				dataGridView_soubory.Columns[0].MinimumWidth = 25;
				dataGridView_soubory.Columns[1].Width = 307;
				dataGridView_soubory.Columns[1].MinimumWidth = 307;
				dataGridView_soubory.Columns[2].Width = 80;
				dataGridView_soubory.Columns[2].MinimumWidth = 80;
				dataGridView_soubory.Columns[3].Width = 115;
				dataGridView_soubory.Columns[3].MinimumWidth = 115;

				//autosize column 1 to fill the dataGridView width
				dataGridView_soubory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

				//set Console app codepage to UTF-8.
				Console.OutputEncoding = System.Text.Encoding.UTF8;
				Console.WindowHeight = 20;

				string versionn = $"{AdbFileManager.Properties.Resources.CurrentCommit.Trim()} 06.07.2025";
				label_version.Text = versionn;
				Console.WriteLine(versionn);

				comboBox_device.SelectedIndex = 0;

			}
			catch(Exception ex) {
				TaskDialog.ShowDialog(new TaskDialogPage() {
					Caption = "Error",
					Text = ex.ToString(),
					Icon = TaskDialogIcon.Error,
					Buttons = { TaskDialogButton.Close },
					Footnote = "Please report this error to the developer. Detailed report may be in console",
					SizeToContent = true
				});
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex);
				Console.ResetColor();
				this.Show();
			}
		}

		public static string adb(string command) {
			Process[] adb = Process.GetProcessesByName("adb");
			if(adb.Length == 0) {
				Console.WriteLine("adb.exe is not running, this may take a while");
				var dt = Form1._Form1.dataGridView_soubory.DataSource as DataTable;
				dt.Rows.Add(new Icon(@"icons\file.ico"), "Starting adb service. This will take a few seconds.", 0, DateTime.UnixEpoch);
				dt.Rows.Add(new Icon(@"icons\file.ico"), "Please be patient", 0, DateTime.UnixEpoch);
				Application.DoEvents();
			}

			if(selectedDevice != null){
				Console.WriteLine("Selected device is not null, using it in adb command: " + selectedDevice.adbId);
				//makes adb use the selected device
				command = command.Replace("adb ", $"adb -s {selectedDevice.adbId} ");
				Console.WriteLine("adb command after replacing:\n" + command);
			}


			Process process = new Process();
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c chcp 65001";
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			Cursor.Current = Cursors.WaitCursor;
			process.Start();
			process.WaitForExit();

			process.StartInfo.Arguments = "/c " + command;
			process.Start();
			string output = process.StandardOutput.ReadToEnd();

			Task handle = process.WaitForExitAsync();

			while(!handle.IsCompleted) {
				Application.DoEvents();
			}
			Application.DoEvents();

			Cursor.Current = Cursors.Default;
			return output;
		}
		private void verticalLabel1_Click(object sender, EventArgs e) {
			Console.WriteLine("verticalLabel1_Click()");
			Console.WriteLine("verticalLabel1_Click()");
			Console.WriteLine("verticalLabel1_Click()");
			refreshDevicesList();
			if(multipleDevicesDetection()) return;
			dataGridView_soubory.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);
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
			Console.WriteLine("CellMouseDoubleClick()");
			if(e.RowIndex >= 0) {
				string name = dataGridView_soubory.Rows[e.RowIndex].Cells[1].Value.ToString();
				string size = dataGridView_soubory.Rows[e.RowIndex].Cells[2].Value.ToString();
				string date = dataGridView_soubory.Rows[e.RowIndex].Cells[3].Value.ToString();
				string permissions = dataGridView_soubory.Rows[e.RowIndex].Cells[4].Value.ToString();
				if(!Functions.isFolder(permissions, checkBox_android6fix.Checked)) {
					if(checkBox_preview.Checked) {
						if(Functions.videoExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase)) || Functions.imageExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase)) || Functions.audioExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) {
							//copy file to temp folder
							string sourcePath = directoryPath + name;
							string destinationPath = tempPath + name;

							if(!temp_folder_created) {
								Directory.CreateDirectory(tempPath);
								temp_folder_created = true;
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
					cur_path_modifyInternal = true;
					cur_path.Text = directoryPath;
					cur_path_modifyInternal = false;
					//MessageBox.Show(directoryPath);
					dataGridView_soubory.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);
				}
			}
		}
		bool copying = false;
		private void android2pc_Click(object sender, EventArgs e) {
			//string destinationFolder = ShellObject.FromParsingName(explorerBrowser1.NavigationLog.CurrentLocation.ParsingName).Properties.System.ItemPathDisplay.Value;
			string destinationFolder = explorerBrowser1.NavigationLog.CurrentLocation.ParsingName;
			//MessageBox.Show(destinationFolder);

			string date = checkBox_filedate.Checked ? " -a " : "";
			List<File> files = new List<File>();
			foreach(DataGridViewRow row in dataGridView_soubory.SelectedRows) {
				//put each selected file into a list
				string name = row.Cells[1].Value.ToString();
				string size = row.Cells[2].Value.ToString();
				string datee = row.Cells[3].Value.ToString();
				string permissions = row.Cells[4].Value.ToString();
				bool isDirectory = Functions.isFolder(permissions, checkBox_android6fix.Checked);
				files.Add(new File(name, size, datee, permissions, isDirectory));
			}

			if(checkBox_unwrapfolders.Checked) {
				ProgressBarMarquee pgm = new ProgressBarMarquee();
				ResourceManager rm = new ResourceManager("AdbFileManager.strings", Assembly.GetExecutingAssembly());
				pgm.set(rm.GetString("unwrap_wait"), rm.GetString("unwrap_wait_title"));
				pgm.Show(); pgm.BringToFront(); pgm.Activate(); pgm.Focus();

			//go through the list, and if there is folder, remove it and add it's contents to the list.
			restart:;
				for(int i = 0; i < files.Count; i++) {
					pgm.redraw();
					File file = files[i];
					if(Functions.isFolder(file, checkBox_android6fix.Checked)) {
						Console.WriteLine("unwraping folder: " + file.name);
						DataTable newfiles_table = Functions.getDir(directoryPath + file.name, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);
						Console.WriteLine("removed folder status: " + files.Remove(file));
						List<File> newfiles = new List<File>();
						foreach(DataRow row in newfiles_table.Rows) {
							//put each selected file into a list
							string name = row.ItemArray[1].ToString();
							string size = row.ItemArray[2].ToString();
							string datee = row.ItemArray[3].ToString();
							string permissions = row.ItemArray[4].ToString();
							bool isDirectory = Functions.isFolder(permissions, checkBox_android6fix.Checked);
							newfiles.Add(new File(file.name + "/" + name, size, datee, permissions, isDirectory));
							Console.WriteLine("added file: " + name);
							pgm.redraw();
						}
						files.AddRange(newfiles);
						if(pgm.cancel) {
							pgm.delete();
							copying = false;
						}
						goto restart;
					}
				}
				pgm.delete();
			}
			int filecount = files.Count();
			int copied = 0;
			Form2 progressbar = new Form2();
			progressbar.Show();
			//try to make the progressbar get shown
			progressbar.BringToFront();
			progressbar.Activate();
			progressbar.Focus();
			copying = true;

			foreach(File file in files) {
				string sourcefile = directoryPath + file.name;
				string destinationFile = $"\"{destinationFolder.Replace('\\', '/')}/{file.name}\"";
				Console.WriteLine(destinationFile);
				string command = $"adb pull {date} \"{sourcefile}\" {Functions.FixWindowsPath(destinationFile)}";
				string final_directory = Path.GetDirectoryName(destinationFile).Replace("\"", "");
				if(!Directory.Exists(final_directory)) {
					Console.WriteLine("Creating directory: " + final_directory);
					Directory.CreateDirectory(final_directory);
				}
				Console.WriteLine(command);
				progressbar.update(copied, filecount, directoryPath, destinationFolder, file.name);
				Console.WriteLine(adb(command));
				copied++;
			}


			progressbar.delete();
			copying = false;

			//string sourceFileName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

		}

		private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			goUpDirectory();
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e) {
			Console.WriteLine("Key pressed in datagrid: " + e.KeyValue);
			if(e.KeyCode == Keys.Enter) {
				clickedFolder();
			}
			else if(e.KeyCode == Keys.Back) {
				goUpDirectory();
			}
		}
		private void explorerBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
			Console.WriteLine("Key pressed in explorer: " + e.KeyValue);
			if(e.KeyCode == Keys.Enter) {
				explorerBrowser1.Navigate(explorerBrowser1.NavigationLog.CurrentLocation);
			}
			else if(e.KeyCode == Keys.Back) {
				goUpDirectory();
			}
		}
		void clickedFolder() {
			Console.WriteLine("clickedFolder();");
			int rowIndex = dataGridView_soubory.CurrentCell.RowIndex;
			if(rowIndex >= 0) {
				string name = dataGridView_soubory.Rows[rowIndex].Cells[1].Value.ToString();
				string size = dataGridView_soubory.Rows[rowIndex].Cells[2].Value.ToString();
				string date = dataGridView_soubory.Rows[rowIndex].Cells[3].Value.ToString();
				if(name.Contains(".")) {
					MessageBox.Show("File: " + name + "\nSize: " + size + "\nDate: " + date);
				}
				else {
					directoryPath = directoryPath + name + "/";
					cur_path.Text = directoryPath;
					//MessageBox.Show(directoryPath);
					dataGridView_soubory.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);
				}
			}
		}

		void goUpDirectory() {
			Console.WriteLine("goUpDirectory();");
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
			cur_path_modifyInternal = true;
			cur_path.Text = directoryPath;
			cur_path_modifyInternal = false;
			dataGridView_soubory.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);
		}
		public bool multipleDevicesDetection(){
			if(foundDevices.Count > 1 && selectedDevice == null) {
				Console.WriteLine("Multiple devices detected, showing message in datagridview");
				Console.WriteLine("Found devices count: " + foundDevices.Count);
				DataTable dt2 = dataGridView_soubory.DataSource as DataTable;
				dt2.Rows.Clear();
				dt2.Rows.Add(new Icon(@"icons\file.ico"), "Multiple devices connected.", 0, DateTime.UnixEpoch);
				int datagridviewWidth = dataGridView_soubory.Columns[1].Width;
				string text = "Please disconnect other devices, or select a wanted device in dropdown thats down right.";

				dataGridView_soubory.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

				// Add the wrapped text as a new row
				dt2.Rows.Add(new Icon(@"icons\file.ico"), text, 0, DateTime.UnixEpoch);

				dataGridView_soubory.Rows[1].Height = 50;

				return true;
			}
			else return false;
		}
		private void timer1_Tick(object sender, EventArgs e) {

			Console.WriteLine("timer ticked");

			timer1.Stop();
			timer1.Enabled = false;

			refreshDevicesList();

			hideConsole();

			if(multipleDevicesDetection()) return;


			DataTable dt = dataGridView_soubory.DataSource as DataTable;
			dt.Rows.Add(new Icon(@"icons\file.ico"), "Loading files in root directory", 0, DateTime.UnixEpoch);


			dataGridView_soubory.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);

			cur_path_modifyInternal = true;
			cur_path.Text = directoryPath;
			cur_path_modifyInternal = false;

			button_pc2android.Invalidate();
			button_android2pc.Invalidate();
			verticalLabel_refresh.Invalidate();
			button_unlock.Invalidate();
			verticalLabel_makedir.Invalidate();

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
				string command = $"adb push {date} \"{sourcefile}\" \"{Functions.FixWindowsPath(directoryPath)}\"";
				Console.WriteLine(command);
				progressbar.update(copied, filecount, explorer_path.Text, directoryPath, sourcefile);
				Console.WriteLine(adb(command));
				copied++;
			}
			progressbar.Close();
			copying = false;
		}

		bool cur_path_modifyInternal = false;
		private void cur_path_TextChanged(object sender, EventArgs e) {
			Console.WriteLine("cur_path_TextChanged();");
			if(cur_path_modifyInternal) {
				Console.WriteLine("cur_path_TextChanged false");
				return;
			}
			if(!directoryPath.EndsWith("/")) {
				Console.WriteLine("cur_path_TextChanged adding / to end of path");
				directoryPath += "/";
			}

			directoryPath = cur_path.Text;
			dataGridView_soubory.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);
		}

		private void Form1_Load(object sender, EventArgs e) {
			Console.WriteLine("Form loaded, starting timer");
			timer1.Enabled = true;
			timer1.Start();
		}

		private void explorerBrowser1_NavigationComplete(object sender, Microsoft.WindowsAPICodePack.Controls.NavigationCompleteEventArgs e) {
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


		bool console_shown = false;
		private void button1_Click(object sender, EventArgs e) {
			console_shown = !console_shown;
			if(console_shown) {
				showConsole();
			}
			else {
				hideConsole();
			}
		}
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		private void hideConsole() {
			var handle = GetConsoleWindow();
			ShowWindow(handle, SW_HIDE);
		}
		private void showConsole() {
			var handle = GetConsoleWindow();
			ShowWindow(handle, SW_SHOW);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			//show console
			var handle = GetConsoleWindow();
			ShowWindow(handle, SW_SHOW);
			Console.BackgroundColor = ConsoleColor.Red;
			Console.ForegroundColor = ConsoleColor.White;

			Console.WriteLine("Closing begin");
			//kill the process adb.exe if it's running
			Process[] adb = Process.GetProcessesByName("adb.exe");
			foreach(Process process in adb) {
				Console.WriteLine("killing adb...");
				process.Kill();
			}
			adb = Process.GetProcessesByName("adb");
			foreach(Process process in adb) {
				Console.WriteLine("killing adb...");
				process.Kill();
			}

			if(Directory.Exists(tempPath)) {
				Console.WriteLine("deleting temp directory...");
				Directory.Delete(tempPath, true);
			}
			Console.WriteLine("Saving old settings...");
			save_settings();
			Console.WriteLine("Saving new settings...");
			SettingsManager.SaveSettings();

			Console.WriteLine("Settings saved!");
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			Console.WriteLine("Exiting Application... This may take few dozen seconds");
			Application.Exit();
			hideConsole();
		}

		enum Languages {
			English,
			Cestina,
			Polski,
			Deutsch,
			Japanese,
			Espanol
		}
		private void save_settings() {
			Properties.Settings.Default.preview_on_doubleclick = checkBox_preview.Checked;
			Properties.Settings.Default.smooth_progressbar = checkBox_unwrapfolders.Checked;
			Properties.Settings.Default.keep_modification_date = checkBox_filedate.Checked;
			Properties.Settings.Default.compatibility = checkBox_android6fix.Checked;
			Properties.Settings.Default.compatibility_fast = checkBox_android6fix_fastmode.Checked;

			Properties.Settings.Default.Save();
		}
		private void load_settings() {
			try {
				checkBox_preview.Checked = Properties.Settings.Default.preview_on_doubleclick;
				checkBox_unwrapfolders.Checked = Properties.Settings.Default.smooth_progressbar;
				checkBox_filedate.Checked = Properties.Settings.Default.keep_modification_date;
				checkBox_android6fix.Checked = Properties.Settings.Default.compatibility;
				checkBox_android6fix_fastmode.Checked = Properties.Settings.Default.compatibility_fast;
			}
			catch {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error loading settings");
				Console.ResetColor();
			}
		}

		private void applyLang() {
			//ushort? loaded_lang = Properties.Settings.Default.lang;
			ushort? loaded_lang = SettingsManager.settings.lang; //load from settings manager
			if(loaded_lang == null) loaded_lang = (ushort)Languages.English;
			switch((Languages)loaded_lang) {
				case Languages.English:
					Console.WriteLine("Setting language to English");
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
					break;
				case Languages.Cestina:
				Console.WriteLine("Nastavování jazyka na Češtinu");
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");
					break;
				case Languages.Polski:
					Console.WriteLine("Ustawianie języka na Polski");
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl");
					break;
				case Languages.Deutsch:
					Console.WriteLine("Sprache auf Deutsch eingestellt");
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
					break;
				case Languages.Japanese:
					Console.WriteLine("言語を日本語に設定しています");
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja"); 
					break;
				case Languages.Espanol:
				Console.WriteLine("Configurando el idioma a Español");
					Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
					break;
			}

		}
		private void buttonback_MouseLeave(object sender, EventArgs e) {
			//this.button_back.Image = Properties.Resources.travel_back_enabled;
			this.button_back.Image = Icons.travel_enabled_back;
		}

		private void buttonback_MouseEnter(object sender, EventArgs e) {
			//this.button_back.Image = Properties.Resources.travel_hot_back;
			this.button_back.Image = Icons.travel_hot_back;
		}

		private void buttonback_MouseDown(object sender, MouseEventArgs e) {
			//this.button_back.Image = Properties.Resources.travel_pressed_back;
			this.button_back.Image = Icons.travel_pressed_back;
		}
		private void buttonback_MouseUp(object sender, MouseEventArgs e) {
			//this.button_back.Image = Properties.Resources.travel_hot_back;
			this.button_back.Image = Icons.travel_hot_back;
		}

		private void buttonforward_MouseLeave(object sender, EventArgs e) {
			//this.button_forward.Image = Properties.Resources.travel_forward_enabled;
			this.button_forward.Image = Icons.travel_enabled_forward;
		}

		private void buttonforward_MouseEnter(object sender, EventArgs e) {
			//this.button_forward.Image = Properties.Resources.travel_hot_forward;
			this.button_forward.Image = Icons.travel_hot_forward;
		}

		private void buttonforward_MouseDown(object sender, MouseEventArgs e) {
			//this.button_forward.Image = Properties.Resources.travel_hot_forward;
			this.button_forward.Image = Icons.travel_pressed_forward;
		}
		private void buttonforward_MouseUp(object sender, MouseEventArgs e) {
			//this.button_forward.Image = Properties.Resources.travel_hot_forward;
			this.button_forward.Image = Icons.travel_hot_forward;
		}

		private void button_back_Click(object sender, EventArgs e) {
			explorerBrowser1.NavigateLogLocation(NavigationLogDirection.Backward);
		}

		private void button_forward_Click(object sender, EventArgs e) {
			explorerBrowser1.NavigateLogLocation(NavigationLogDirection.Forward);
		}

		private void checkBox_android6fix_CheckedChanged(object sender, EventArgs e) {
			if(checkBox_android6fix.Checked) checkBox_android6fix_fastmode.Visible = true;
			else checkBox_android6fix_fastmode.Visible = false;
		}

		//responsivity go brrr
		private void Form1_Resize(object sender, EventArgs e) {
			const int margin = 24;
			const int middleSpace = 52;

			int realWidth = this.Width - 16; //"form size" includes the windows borders for some reason 🤨
			int realHeight = this.Height - 39;
			int x = realWidth - 100;

			//panel_main.Width = realWidth;
			//panel_main.Height = realHeight;
			//panel_main.Left = 0;
			//panel_main.Top = 0;

			int listAndroidWidth = x / 2;
			int listPCWidth = x - listAndroidWidth;

			dataGridView_soubory.Width = listAndroidWidth;
			cur_path.Width = listAndroidWidth;

			panel_tlacitkaUprostred.Left = margin + listAndroidWidth - 1;

			explorerBrowser1.Width = listPCWidth;
			explorerBrowser1.Left = margin + listAndroidWidth + middleSpace;
			explorerBrowser1.Height = this.Height - 104;

			button_back.Left = margin + listAndroidWidth + middleSpace;
			button_forward.Left = margin + listAndroidWidth + middleSpace + 26;
			explorer_path.Width = listPCWidth - 57;
			explorer_path.Left = margin + listAndroidWidth + middleSpace + 57;

			verticalLabel_refresh.BringToFront();

			panel_dolniTlacitka.Width = this.Width;
			panel_dolniTlacitka.Left = 0;
			label_version.Left = this.Width - 121;
			button1.Left = this.Width - 134;
			comboBox_lang.Left = this.Width - 242;

			button_unlock.Left = this.Width - 297;
			deco_panel6.Left = this.Width - 297;

			button_console.Left = this.Width - 136;

			deco_panel4.Left = this.Width - 216;
		}

		private void button_unlock_Click(object sender, EventArgs e) {
			UnlockForm unlock = new UnlockForm();
			unlock.Show();
		}

		private void button_makedir_Click(object sender, EventArgs e) {
			//show form dialog with textbox input for directory name
			Form directoryNameForm = new Form();
			directoryNameForm.Text = "Enter directory name";
			directoryNameForm.Size = new Size(300, 100);
			directoryNameForm.StartPosition = FormStartPosition.CenterParent;
			TextBox dirName = new TextBox();
			dirName.Size = new Size(260, 20);
			dirName.Location = new Point(10, 10);
			Button okButton = new Button();
			okButton.Text = "OK";
			okButton.Size = new Size(75, 23);
			directoryNameForm.Controls.Add(dirName);
			directoryNameForm.Controls.Add(okButton);

			//set ok button to close the form and return the value from textbox
			okButton.Click += (sender, e) => {
				directoryNameForm.DialogResult = DialogResult.OK;
				directoryNameForm.Close();
			};
			DialogResult result = directoryNameForm.ShowDialog();
			if(result == DialogResult.OK) {
				string directoryName = dirName.Text;
				string command = $"adb shell mkdir \"{directoryPath}/{directoryName}\"";
				Console.WriteLine(command);
				string output = adb(command);
				Console.WriteLine(output);
				dataGridView_soubory.DataSource = Functions.getDir(directoryPath, checkBox_android6fix.Checked, checkBox_android6fix_fastmode.Checked);
			}
		}

		private void panel_tlacitkaUprostred_Paint(object sender, PaintEventArgs e) {

		}

		private void panel_dolniTlacitka_Paint(object sender, PaintEventArgs e) {

		}

		private void button_openSettings_Click(object sender, EventArgs e) {
			SettingsForm settingsForm = new SettingsForm();
			settingsForm.ShowDialog(this);
		}

		private void comboBox_device_SelectedIndexChanged(object sender, EventArgs e) {
			if(modifyingComboBox) return; //prevent infinite loop when refreshing devices list
			if(comboBox_device.SelectedIndex == 1){ //Wireless option
				//open dialog WirelessPair
				WirelessPair wirelessPair = new WirelessPair();
				DialogResult result = wirelessPair.ShowDialog(this);
				comboBox_device.SelectedIndex = 0; //reset to default device
				refreshDevicesList(); //refresh the list of devices
			}
			if(comboBox_device.SelectedIndex >= 2){
				int deviceIndex = comboBox_device.SelectedIndex - 2; //first two is default and wireless so we can just - 2
				if(deviceIndex < foundDevices.Count) {
					selectedDevice = foundDevices[deviceIndex];
					Console.WriteLine($"Selected device: {selectedDevice.model} ({selectedDevice.adbId})");
					//set the selected device in adb
					//string command = $"adb -s {selectedDevice.adbId} shell";
					//Console.WriteLine(command);
					//adb(command);
				}
				else {
					Console.WriteLine("Selected device index out of range");
				}
			}
			else{
				selectedDevice = null; //reset to default device
			}
		}
		public static Device? selectedDevice = null; //null = default
		public List<Device> foundDevices = new List<Device>();
		public class Device {
			public string adbId { get; set; }
			public string state { get; set; }
			public string product { get; set; }
			public string model { get; set; }
			public string device { get; set; }
			public string transportId { get; set; }
		}
		bool modifyingComboBox = false; //to prevent infinite loop when refreshing devices list
		public void refreshDevicesList(){
			Console.WriteLine("Refreshing devices list...");
			string command = "adb devices -l";
			Console.WriteLine(command);
			string output = adb(command);
			Console.WriteLine(output);
			string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			lines = lines.Skip(1).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

			modifyingComboBox = true;
			comboBox_device.Items.Clear();
			comboBox_device.Items.Add("Default device");
			comboBox_device.Items.Add("Add wireless");
			foundDevices.Clear();
			var ipPattern = new Regex(@"^\s*(\d{1,3}\.){3}\d{1,3}:\d{1,5}");

			foreach(var line in lines) {
				// adb-REDACTED._adb-tls-connect._tcp device product:EU_AI2302 model:ASUS_AI2302 device:ASUS_AI2302 transport_id:1
				var device = new Device();

				var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				if(parts.Length < 2) continue;

				device.adbId = parts[0];
				device.state = parts[1];

				for(int i = 2; i < parts.Length; i++) {
					var kv = parts[i].Split(':', 2);
					if(kv.Length == 2) {
						switch(kv[0]) {
							case "product":
								device.product = kv[1];
								break;
							case "model":
								device.model = kv[1];
								break;
							case "device":
								device.device = kv[1];
								break;
							case "transport_id":
								device.transportId = kv[1];
								break;
						}
					}
				}
				string neautorizovano = device.state == "unauthorized" ? " (UNAUTHORIZED)" : "";
				string offline = device.state == "offline" ? " (OFFLINE)" : "";
				string bezdrat = device.adbId.Contains("tcp") || ipPattern.IsMatch(device.adbId) ? " (Wireless)" : "";
				comboBox_device.Items.Add($"{device.model ?? device.adbId}" + neautorizovano + bezdrat + offline);
				foundDevices.Add(device);
			}
			comboBox_device.DropDownWidth = Math.Max(200, comboBox_device.Items.Cast<string>().Max(item => TextRenderer.MeasureText(item, comboBox_device.Font).Width) + 20);
			Application.DoEvents();
			modifyingComboBox = false;
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
		static bool fastcompatibility = false;
		public static bool isFolder(string path, bool old_android) {
			if(old_android) return legacyAndroid.isFolder(path, fastcompatibility);
			if(path == null) return false;
			if(path.ToLower().Trim()[0] == 'd') return true; //the first character of the line is 'd' if it's a directory
			else return false;
		}
		public static bool isFolder(File file, bool old_android) {
			if(old_android) return legacyAndroid.isFolder(file, fastcompatibility);
			if(file.permissions.ToLower().Trim()[0] == 'd') return true; //the first character of the line is 'd' if it's a directory
			else return false;
		}

		public static DataTable getDir(string directoryPath, bool old_android, bool old_android_fast) {
			
			if(old_android) {
				fastcompatibility = old_android_fast;
				legacyAndroid.fastcompatibility = old_android_fast;
				return legacyAndroid.getDir(directoryPath);
			}
			Cursor.Current = Cursors.WaitCursor;

			// Retrieve a list of files in the specified directory

			string command = $"adb shell ls -lL \"'{directoryPath}'\"";
			Console.WriteLine(command);
			string output = Form1.adb(command);
			string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

			string filteredOutput = string.Join(Environment.NewLine, lines);
			Console.WriteLine(filteredOutput);

			List<string[]> fileList = new List<string[]>();
			try {
				string[] files = filteredOutput.ToString().Split('\n');
				var dgv = new DataTable();

				dgv.Columns.Add("ico", typeof(Icon));
				/*dgv.Columns.Add("Name");
				dgv.Columns.Add("Size (KiB)", typeof(decimal));
				dgv.Columns.Add("Date", typeof(DateTime));
				dgv.Columns.Add("Attr");*/
				dgv.Columns.Add(Form1.rm.GetString("datagridview_name"));
				dgv.Columns.Add(Form1.rm.GetString("datagridview_size"), typeof(decimal));
				dgv.Columns.Add(Form1.rm.GetString("datagridview_date"), typeof(DateTime));
				dgv.Columns.Add(Form1.rm.GetString("datagridview_attr"));

				foreach(string filee in files.Skip(1)) {
					string file = filee.Trim();
					try {
						if(!string.IsNullOrWhiteSpace(file)) {
							/* line examples
							"drwx------ 9 u0_a201  u0_a201     8192 2023-06-17 13:26 Music"
							 "-rw------- 1 u0_a201  u0_a201  1331648 2021-11-22 00:42 SpaceCadetPinball.cia"
							 "-rw------- 1 u0_a201  u0_a201  1365560 2021-01-19 04:14 Not\ Funny,\ Didn't\ HahahÃ¦.webm"*/
							string[] attributes = CustomSplit(file, ' ');

							string permissions = attributes[0];
							int links = int.Parse(attributes[1]);
							string owner = attributes[2];
							string group = attributes[3];
							decimal size = decimal.Round(decimal.Parse(attributes[4]) / 1024, 3);

							DateTime date = DateTime.Parse(attributes[5] + " " + attributes[6]);
							string name = string.Join(' ', attributes.Skip(7));
							Icon icon;
							try {
								icon = UIStyle.GetIcon(file, isFolder(permissions, old_android));
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
					if(directoryPath == "/sdcard/") {
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "Make sure USB debugging is enabled, and your device", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "is properly connected.", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "To enable USB debugging:", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "1. Go to android settings", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "2. System", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "3. Information about phone", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "4. Find build number and click it repeatedly, ", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "    Until \"developer mode is now enabled\" notification", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "5. go back, and find \"developer settings\"", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "6. find \"USB Debugging\" and enable it", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "7. Enable \"Disable adb authorization time limit\"", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "8. connect your phone to PC, and click authorize PC", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "9. Files should now show here properly", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "", 0, DateTime.UnixEpoch);
						dgv.Rows.Add(new Icon(@"icons\file.ico"), "Please note that these steps may vary by phone", 0, DateTime.UnixEpoch);

					}
				}
				else if(dgv.Rows.Count > 18) {
					Form1._Form1.dataGridView_soubory.Columns[1].Width = 290;
				}
				else Form1._Form1.dataGridView_soubory.Columns[1].Width = 307;

				Cursor.Current = Cursors.Default;
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


				Cursor.Current = Cursors.Default;
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

		public static void set_language(string jazyk) {
			if(jazyk == "Polski") {
				Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl");
			}
			else if(jazyk == "Čeština") {
				Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");
			}
			else {
				Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
			}
		}
		public static string FixWindowsPath(string path) {
			path.Replace('\\', '/');
			path.Replace("C:/Usuarios", "C:/Users");
			path.Replace("C:/Usuários", "C:/Users");
		    
			return path;
		}
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
	public static class Util {
		static public T Find<T>(Control container) where T : Control {
			foreach(Control child in container.Controls)
				return (child is T ? (T)child : Find<T>(child));
			// Not found.
			return null;
		}
	}
}
