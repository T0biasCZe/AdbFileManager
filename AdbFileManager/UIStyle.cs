using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace AdbFileManager {
	public static class Icons {
		public static Icon folder_image = new Icon(@"icons\folder_image.ico");
		public static Icon folder_downloads = new Icon(@"icons\folder_downloads.ico");
		public static Icon folder_music = new Icon(@"icons\folder_music.ico");
		public static Icon folder_video = new Icon(@"icons\folder_video.ico");
		public static Icon folder_document = new Icon(@"icons\folder_document.ico");
		public static Icon folder_android = new Icon(@"icons\folder_android.ico");
		public static Icon folder_files = new Icon(@"icons\folder2.ico");
		public static Icon folder_empty = new Icon(@"icons\folder.ico");
		public static Icon image2 = new Icon(@"icons\image2.ico");
		public static Icon video2 = new Icon(@"icons\video2.ico");
		public static Icon rom = new Icon(@"icons\rom.ico");
		public static Icon music2 = new Icon(@"icons\music2.ico");
		public static Icon doc2 = new Icon(@"icons\doc2.ico");
		public static Icon archive = new Icon(@"icons\archive.ico");
		public static Icon exe = new Icon(@"icons\exe.ico");
		public static Icon file = new Icon(@"icons\file.ico");
		public static Icon console = new Icon(@"icons\console.ico");

		public static Bitmap travel_disabled_back = new Bitmap(@"icons\travel_disabled_back.png");
		public static Bitmap travel_disabled_forward = new Bitmap(@"icons\travel_disabled_forward.png");
		public static Bitmap travel_enabled_back = new Bitmap(@"icons\travel_enabled_back.png");
		public static Bitmap travel_enabled_forward = new Bitmap(@"icons\travel_enabled_forward.png");
		public static Bitmap travel_pressed_back = new Bitmap(@"icons\travel_pressed_back.png");
		public static Bitmap travel_pressed_forward = new Bitmap(@"icons\travel_pressed_forward.png");
		public static Bitmap travel_hot_back = new Bitmap(@"icons\travel_hot_back.png");
		public static Bitmap travel_hot_forward = new Bitmap(@"icons\travel_hot_forward.png");
	}
	public static class UIStyle {
		public static void ApplyModernTheme(Form1 form1){
			if(SettingsManager.settings.ButtonTheme == 2){
				form1.deco_panel1.Visible = false;
				form1.button_android2pc.BackColor = Color.Gainsboro;
				form1.button_android2pc.UseFluent = true;
				form1.button_android2pc.Width += 4;

				form1.deco_panel2.Visible = false;
				form1.button_pc2android.BackColor = Color.Gainsboro;
				form1.button_pc2android.UseFluent = true;
				form1.button_pc2android.Width += 4;

				form1.deco_panel3.Visible = false;
				form1.verticalLabel_refresh.BackColor = Color.Gainsboro;
				form1.verticalLabel_refresh.Width += 4;
				form1.verticalLabel_refresh.Left -= 1;
				form1.verticalLabel_refresh.UseFluent = true;

				//form1.deco_panel4.Visible = false;
				//form1.button_unlock.UseFluent = true;

				form1.deco_panel5.Visible = false;
				form1.verticalLabel_makedir.BackColor = Color.Gainsboro;
				form1.verticalLabel_makedir.Width += 4;
				form1.verticalLabel_makedir.Left -= 1;
				form1.verticalLabel_makedir.UseFluent = true;
			}


			if(SettingsManager.settings.UseWindows11Icons) {

				if(Path.Exists(@"iconsW11\folder_image.ico")) {
					Icons.folder_image = new Icon(@"iconsW11\folder_image.ico");
				}
				if(Path.Exists(@"iconsW11\folder_downloads.ico")) {
					Icons.folder_downloads = new Icon(@"iconsW11\folder_downloads.ico");
				}
				if(Path.Exists(@"iconsW11\folder_music.ico")) {
					Icons.folder_music = new Icon(@"iconsW11\folder_music.ico");
				}
				if(Path.Exists(@"iconsW11\folder_video.ico")) {
					Icons.folder_video = new Icon(@"iconsW11\folder_video.ico");
				}
				if(Path.Exists(@"iconsW11\folder_document.ico")) {
					Icons.folder_document = new Icon(@"iconsW11\folder_document.ico");
				}
				if(Path.Exists(@"iconsW11\folder_android.ico")) {
					Icons.folder_android = new Icon(@"iconsW11\folder_android.ico");
				}
				if(Path.Exists(@"iconsW11\folder2.ico")) {
					Icons.folder_files = new Icon(@"iconsW11\folder2.ico");
				}
				if(Path.Exists(@"iconsW11\folder.ico")) {
					Icons.folder_empty = new Icon(@"iconsW11\folder.ico");
				}
				if(Path.Exists(@"iconsW11\image2.ico")) {
					Icons.image2 = new Icon(@"iconsW11\image2.ico");
				}
				if(Path.Exists(@"iconsW11\video2.ico")) {
					Icons.video2 = new Icon(@"iconsW11\video2.ico");
				}
				if(Path.Exists(@"iconsW11\rom.ico")) {
					Icons.rom = new Icon(@"iconsW11\rom.ico");
				}
				if(Path.Exists(@"iconsW11\music2.ico")) {
					Icons.music2 = new Icon(@"iconsW11\music2.ico");
				}
				if(Path.Exists(@"iconsW11\doc2.ico")) {
					Icons.doc2 = new Icon(@"iconsW11\doc2.ico");
				}
				if(Path.Exists(@"iconsW11\archive.ico")) {
					Icons.archive = new Icon(@"iconsW11\archive.ico");
				}
				if(Path.Exists(@"iconsW11\exe.ico")) {
					Icons.exe = new Icon(@"iconsW11\exe.ico");
				}
				if(Path.Exists(@"iconsW11\file.ico")) {
					Icons.file = new Icon(@"iconsW11\file.ico");
				}

				if(Path.Exists(@"iconsW11\travel_disabled_back.png")) {
					Icons.travel_disabled_back = new Bitmap(@"iconsW11\travel_disabled_back.png");
				}
				if(Path.Exists(@"iconsW11\travel_disabled_forward.png")) {
					Icons.travel_disabled_forward = new Bitmap(@"iconsW11\travel_disabled_forward.png");
				}
				if(Path.Exists(@"iconsW11\travel_enabled_back.png")) {
					Icons.travel_enabled_back = new Bitmap(@"iconsW11\travel_enabled_back.png");
				}
				if(Path.Exists(@"iconsW11\travel_enabled_forward.png")) {
					Icons.travel_enabled_forward = new Bitmap(@"iconsW11\travel_enabled_forward.png");
				}
				if(Path.Exists(@"iconsW11\travel_pressed_back.png")) {
					Icons.travel_pressed_back = new Bitmap(@"iconsW11\travel_pressed_back.png");
				}
				if(Path.Exists(@"iconsW11\travel_pressed_forward.png")) {
					Icons.travel_pressed_forward = new Bitmap(@"iconsW11\travel_pressed_forward.png");
				}
				if(Path.Exists(@"iconsW11\travel_hot_back.png")) {
					Icons.travel_hot_back = new Bitmap(@"iconsW11\travel_hot_back.png");
				}
				if(Path.Exists(@"iconsW11\travel_hot_forward.png")) {
					Icons.travel_hot_forward = new Bitmap(@"iconsW11\travel_hot_forward.png");
				}
			}

			form1.button_back.Image = Icons.travel_enabled_back;
			form1.button_forward.Image = Icons.travel_enabled_forward;
			using(var icon16 = new Icon(Icons.console, new Size(16, 16))) {
				form1.button_console.Image = icon16.ToBitmap();
			}

		}
		public static Color backColor = ColorTranslator.FromHtml("#202020");
		public static Color darkerBackColor = ColorTranslator.FromHtml("#151515");
		public static Color brighterBackColor = ColorTranslator.FromHtml("#404040");
		public static Color foreColor = ColorTranslator.FromHtml("#FFFFFF");
		public static Color selectedColor = ColorTranslator.FromHtml("#0000FF");
		public static void LoadDarkMode(Form1 form1) {
			form1.button_android2pc.EnableDarkMode();
			form1.button_pc2android.EnableDarkMode();
			form1.verticalLabel_refresh.EnableDarkMode();
			form1.verticalLabel_makedir.EnableDarkMode();


			form1.BackColor = darkerBackColor;

			form1.dataGridView_soubory.BackgroundColor = backColor;
			form1.dataGridView_soubory.DefaultCellStyle.BackColor = backColor;
			form1.dataGridView_soubory.DefaultCellStyle.ForeColor = foreColor;
			form1.dataGridView_soubory.DefaultCellStyle.SelectionBackColor = selectedColor;
			form1.dataGridView_soubory.DefaultCellStyle.SelectionForeColor = foreColor;
			form1.dataGridView_soubory.ColumnHeadersDefaultCellStyle.BackColor = backColor;
			form1.dataGridView_soubory.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
			form1.dataGridView_soubory.RowHeadersDefaultCellStyle.BackColor = backColor;
			form1.dataGridView_soubory.RowHeadersDefaultCellStyle.ForeColor = foreColor;
			form1.dataGridView_soubory.RowHeadersDefaultCellStyle.SelectionBackColor = selectedColor;
			form1.dataGridView_soubory.RowHeadersDefaultCellStyle.SelectionForeColor = foreColor;
			form1.dataGridView_soubory.ColumnHeadersDefaultCellStyle.BackColor = brighterBackColor;
			form1.dataGridView_soubory.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
			form1.dataGridView_soubory.ColumnHeadersDefaultCellStyle.SelectionBackColor = selectedColor;
			form1.dataGridView_soubory.EnableHeadersVisualStyles = false;

			form1.dataGridView_soubory.GridColor = Color.FromArgb(64, 64, 64);

			try {
				Util.Find<HScrollBar>(form1.dataGridView_soubory).BackColor = Color.Red;
			}
			catch { }
			try {
				Util.Find<VScrollBar>(form1.dataGridView_soubory).BackColor = Color.Red;
			}
			catch { }

			form1.cur_path.BackColor = backColor;
			form1.cur_path.ForeColor = foreColor;
			form1.explorer_path.BackColor = backColor;
			form1.explorer_path.ForeColor = foreColor;

			form1.button_goUpDirectory.BackColor = brighterBackColor;
			form1.button_goUpDirectory.ForeColor = foreColor;

			form1.button_android2pc.BackColor = brighterBackColor;
			form1.button_android2pc.ForeColor = foreColor;
			form1.button_pc2android.BackColor = brighterBackColor;
			form1.button_pc2android.ForeColor = foreColor;
			form1.verticalLabel_refresh.BackColor = brighterBackColor;
			form1.verticalLabel_refresh.ForeColor = foreColor;
			form1.verticalLabel_makedir.BackColor = brighterBackColor;
			form1.verticalLabel_makedir.ForeColor = foreColor;

			form1.button_unlock.BackColor = brighterBackColor;
			form1.button_unlock.ForeColor = foreColor;
			form1.button_openSettings.BackColor = brighterBackColor;
			form1.button_openSettings.ForeColor = foreColor;

			form1.comboBox_device.BackColor = brighterBackColor;
			form1.comboBox_device.ForeColor = foreColor;
			form1.comboBox_device.FlatStyle = FlatStyle.Flat;



			form1.deco_panel1.BackColor = Color.Black;
			form1.deco_panel2.BackColor = Color.Black;
			form1.deco_panel3.BackColor = Color.Black;
			form1.deco_panel4.BackColor = Color.Black;
			form1.deco_panel5.BackColor = Color.Black;
			form1.deco_panel6.BackColor = Color.Black;


			form1.panel_installAssistant.BackColor = backColor;
			form1.label_textInstall.ForeColor = foreColor;
			form1.commandLink_installGoAway.MainTextColor = Color.Red;
			form1.commandLink_installYes.MainTextColor = Color.LimeGreen;

			form1.panel_dolniTlacitka.BackColor = selectedColor;
			form1.label_version.LinkColor = Color.SkyBlue;
			foreach(Control control in form1.panel_dolniTlacitka.Controls) {
				if(control is CheckBox) {
					control.ForeColor = Color.White;
				}
			}
		}

		public static string[] imageExtensions = {
	".jpg", ".jpeg", ".png", ".raw", ".jxl", ".bmp", ".webp", ".heif", ".heic", ".mpo", ".gif", ".tiff", ".tif", ".ico", ".svg", ".dds", ".jfif", ".pbm", ".pgm", ".ppm", ".pnm", ".ras", ".exr", ".icns" };
		public static string[] videoExtensions = {
	".mp4", ".mkv", ".webm", ".avi", ".mov", ".wmv", ".flv", ".3gp", ".m4v", ".mpg", ".mpeg", ".m2v", ".m2ts", ".mts", ".ts", ".vob", ".divx", ".xvid", ".ogv", ".rm", ".rmvb", ".asf", ".f4v", ".dat", ".dvr-ms", ".mxf" };
		public static string[] romExtensions = {
	".nes", ".snes", ".smc", ".gba", ".gbc", ".gb", ".nds", ".n64", ".z64", ".psx", ".iso", ".cia", ".3ds", ".3dsx", ".wbfs", ".rvz", ".bin", ".gen", ".sms", ".gg", ".pce", ".cue", ".md", ".tap", ".d64", ".prg", ".gcm", ".gcz", ".wad", ".sgb", ".ws", ".wsc", ".lnx", ".a26", ".a78", ".jag", ".col", ".int", ".rom", ".fds" };
		public static string[] audioExtensions = {
	".mp3", ".wav", ".ogg", ".opus", ".flac", ".m4a", ".aac", ".wma", ".mod", ".mid", ".s3m", ".midi", ".xm", ".it", ".aiff", ".aif", ".amr", ".au", ".ra", ".ac3", ".alac", ".ape", ".dsf", ".dff", ".wv", ".mp2", ".mp1", ".spx" };
		public static string[] documentExtensions = {
	".docx", ".doc", ".pdf", ".txt", ".pptx", ".ppt", ".xlsx", ".xls", ".odt", ".ods", ".odp", ".rtf", ".csv", ".md", ".tex", ".epub", ".fb2", ".djvu", ".log", ".xml", ".json", ".yml", ".yaml" };
		public static string[] archiveExtensions = {
	".zip", ".rar", ".7z", ".tar", ".gz", ".bz2", ".xz", ".tgz", ".tbz2", ".lz", ".lzma", ".z", ".cab", ".iso", ".img", ".apk", ".arj", ".ace", ".sit", ".hqx", ".cbr", ".cbz" };
		public static string[] executableExtensions = {
	".exe", ".dll", ".bat", ".msi", ".jar", ".py", ".sh", ".apk", ".com", ".cmd", ".gadget", ".wsf", ".vbs", ".ps1", ".app", ".scr", ".deb", ".rpm", ".bin", ".run", ".msu" };

		public static Icon GetIcon(string file, bool isFolder){
			Icon icon = null;
			if(isFolder) {
				if(file.Contains("dcim", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_image;
				else if(file.EndsWith(@"download", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_downloads;
				else if(file.EndsWith(@"music", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
				else if(file.EndsWith(@"movies", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_video;
				else if(file.EndsWith(@"documents", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_document;
				else if(file.EndsWith(@"ringtones", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
				else if(file.EndsWith(@"alarms", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
				else if(file.EndsWith(@"sounds", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
				else if(file.EndsWith(@"notifications", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
				else if(file.EndsWith(@"podcasts", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_music;
				else if(file.EndsWith(@"memo", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_document;
				else if(file.EndsWith(@"pictures", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_image;
				else if(file.EndsWith(@"android", StringComparison.OrdinalIgnoreCase)) icon = Icons.folder_android;

				else icon = Icons.folder_files;
			}

			else if(imageExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.image2;
			else if(videoExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.video2;
			else if(romExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.rom;
			else if(audioExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.music2;
			else if(documentExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.doc2;
			else if(archiveExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.archive;
			else if(executableExtensions.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase))) icon = Icons.exe;
			else icon = Icons.file;

			return icon;
		}
	}
}
