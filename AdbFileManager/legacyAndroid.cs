using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AdbFileManager {
	public static class legacyAndroid {
		public static bool fastcompatibility = false;
		public static DataTable getDir(string directoryPath) {
			// Retrieve a list of files in the specified directory without additional details
			string command = $"adb shell ls \"'{directoryPath}'\"";
			Console.WriteLine(command);
			string output = Form1.adb(command);
			string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

			string filteredOutput = string.Join(Environment.NewLine, lines);
			Console.WriteLine(filteredOutput);
			Cursor.Current = Cursors.Default;

			List<string> fileList = new List<string>();
			try {
				string[] files = filteredOutput.ToString().Split('\n');
				var dgv = new DataTable();

				dgv.Columns.Add("ico", typeof(Icon));
				dgv.Columns.Add(Form1.rm.GetString("datagridview_name"));
				dgv.Columns.Add(Form1.rm.GetString("datagridview_size"), typeof(decimal));
				dgv.Columns.Add(Form1.rm.GetString("datagridview_date"), typeof(DateTime));
				dgv.Columns.Add(Form1.rm.GetString("datagridview_attr"));

				foreach(string fileName in files.Skip(1)) {
					string name = fileName.Trim();
					try {
						if(!string.IsNullOrWhiteSpace(name)) {
							// Attempt to change the directory to determine if it's a folder
							/*bool isFolder = false;
							string wholePath = directoryPath + "/" + name;
							string cdCommand = $"adb shell ls \"{wholePath}\"";
							string cdOutput = Form1.adb(cdCommand);
							if(!cdOutput.Trim().Equals(wholePath.Trim())) {
								isFolder = true;
							}*/
							bool isFolder = legacyAndroid.isFolder(directoryPath + "/" + name, fastcompatibility);



							// Set unused variables to default values
							decimal size = 0;
							DateTime date = DateTime.UnixEpoch;
							string permissions = isFolder ? "d---------" : "----------";

							Icon icon;
							try {
								if(isFolder) {
									if(name.Contains("dcim", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_image;
									else if(name.EndsWith(@"download", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_downloads;
									else if(name.EndsWith(@"music", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(name.EndsWith(@"movies", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_video;
									else if(name.EndsWith(@"documents", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_document;
									else if(name.EndsWith(@"ringtones", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(name.EndsWith(@"alarms", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(name.EndsWith(@"notifications", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else if(name.EndsWith(@"podcasts", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
									else icon = Icons.folder_image;
								}

								else if(Functions.imageExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.image2;
								else if(Functions.videoExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.video2;
								else if(Functions.romExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.rom;
								else if(Functions.audioExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.music2;
								else if(Functions.documentExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.doc2;
								else if(Functions.archiveExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.archive;
								else if(Functions.executableExtensions.Any(x => name.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.archive;
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
					Form1._Form1.dataGridView_soubory.Columns[1].Width = 290;
				}
				else {
					Form1._Form1.dataGridView_soubory.Columns[1].Width = 307;
				}

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
		public static bool isFolder(string path, bool fastmode) {
			if(fastmode) return isFolder_fastmode(path);
			bool isFolder = false;
			//string wholePath = directoryPath + "/" + name;
			Console.Write($"checking if \"{path}\" is a folder: ");
			string cdCommand = $"adb shell ls \"'{path}'\"";
			string cdOutput = Form1.adb(cdCommand);
			if(!cdOutput.Trim().Equals(path.Trim())) {
				isFolder = true;
			}
			Console.WriteLine(isFolder);
			return isFolder;
		}
		public static bool isFolder_fastmode(string path) {
			bool isFolder = false;
			//check if file has extension, if not, it's a folder
			Console.Write($"fastchecking if \"{path}\" is a folder: ");
			if(!path.Contains(".")) isFolder = true;
			Console.WriteLine(isFolder);
			return isFolder;
		}
		public static bool isFolder(File file, bool fastmode) {
			return legacyAndroid.isFolder(file.name, fastmode);
		}

	}
}
