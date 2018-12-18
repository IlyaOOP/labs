using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO; 
using System.IO.Compression;

namespace lab13_XAMARIN
{
	static class KIOLog
	{
		static FileSystemWatcher watcher = new FileSystemWatcher{
			Path = @"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\lab13_XAMARIN",
			IncludeSubdirectories = true,
			NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
		};
				
		public static void Start(){   
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			watcher.Created += new FileSystemEventHandler(OnChanged);
			watcher.Deleted += new FileSystemEventHandler(OnChanged);

			watcher.EnableRaisingEvents = true;
		}
			
		public static void SearchByDate(string date){
			watcher.EnableRaisingEvents = false;

			using (StreamReader sr = new StreamReader(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOlogfile.txt"))
			{
				while (!sr.EndOfStream){
					if (sr.ReadLine().StartsWith(date)){
						Console.WriteLine(sr.ReadLine());
					}
				}
			}
		}
			
		private static void OnChanged(object sender, FileSystemEventArgs e){
			using (StreamWriter sw = new StreamWriter(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOlogfile.txt", true))
			{
				sw.WriteLine(DateTime.Now + "___" + e.ChangeType + "___путь: " + e.FullPath);
			}
		}
	}

	static class KIODiskInfo
	{
		public static void freeplace(string diskname){
			foreach (DriveInfo dri in DriveInfo.GetDrives()) {
				if (dri.Name == diskname && dri.IsReady) {
					Console.WriteLine ("свободно места на диске "+dri.Name+": "+dri.AvailableFreeSpace);
				}
			}
			Console.WriteLine ("_______________________________________________________________________");
		}

		public static void infoflsystem(string diskname)
		{
			foreach (DriveInfo dri in DriveInfo.GetDrives()) {
				if (dri.Name == diskname && dri.IsReady) {
					Console.WriteLine ("файловая система "+dri.DriveFormat);
				}
			}
			Console.WriteLine ("_______________________________________________________________________");
		}

		public static void infoforeachdisk()
		{
			foreach (DriveInfo dri in DriveInfo.GetDrives()) {
				if (dri.IsReady) {
					Console.WriteLine ("Имя диска: " + dri.Name + "\nОбъем диска: " + dri.TotalSize + "\nДоступный объем диска" + dri.TotalFreeSpace + "\nМетка тома: " + dri.VolumeLabel);
				}
			}
			Console.WriteLine ("_______________________________________________________________________");
		}

	}

	static class KIOFileinfo
	{
		public static void path(string file)
		{
			FileInfo fli = new FileInfo (file);

			Console.WriteLine ("Полный путь к файлу: " + fli.FullName);

			Console.WriteLine ("_______________________________________________________________________");
		}

		public static void size_name(string file)
		{
			FileInfo fli = new FileInfo (file);

			Console.WriteLine ("Размер: " + fli.Length + "\nРасширение: " + fli.Extension + "\nИмя: " + fli.Name);

			Console.WriteLine ("_______________________________________________________________________");
		}

		public static void cratetime(string file)
		{
			FileInfo fli = new FileInfo (file);

			Console.WriteLine ("Время создания: "+fli.CreationTime);
			Console.WriteLine ("_______________________________________________________________________");
		}
	}

	static class KIODirInfo
	{
		public static void filescount(string dir)
		{
			if (Directory.Exists (dir)) {
				Console.WriteLine ("В директории " + dir + " " + Directory.GetFiles (dir).Length + " файлов");
			}
			Console.WriteLine ("_______________________________________________________________________");
		}

		public static void createtime(string dir)
		{
			if (Directory.Exists (dir)) {
				Console.WriteLine ("Время создания директории " + dir + ": " + Directory.GetCreationTime(dir));
			}
			Console.WriteLine ("_______________________________________________________________________");
		}

		public static void countsubdir(string dir)
		{
			if (Directory.Exists (dir)) {
				Console.WriteLine ("количество поддиректориев: " + Directory.GetDirectories(dir).Length);
			}
			Console.WriteLine ("_______________________________________________________________________");
		}

		public static void listofparentdir(string dir)
		{
			if (Directory.Exists (dir)) {
				Console.WriteLine ("список родительских директориев: " + Directory.GetParent(dir));
			}
			Console.WriteLine ("_______________________________________________________________________");
		}
	}

	static class KIOFileManager
	{
		public static void check(string drivename)
		{
			DirectoryInfo dri = new DirectoryInfo (drivename);

			FileInfo[] fli = dri.GetFiles ();

			Directory.CreateDirectory (@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect");

			using(StreamWriter srw = new StreamWriter(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect\KIODirinfo.txt"))
			{
				foreach (FileInfo i in fli) {
					srw.WriteLine (i);
				}
				foreach (DirectoryInfo i in dri.GetDirectories()) {
					srw.WriteLine (i);
				}
			}

			File.Copy (@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect\KIODirinfo.txt", @"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect\KIODirinfoCOPY.txt");
			File.Delete (@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect\KIODirinfo.txt");
		}

		public static void copy(string dir, string ext)
		{
			Directory.CreateDirectory (@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOFiles");

			DirectoryInfo dri = new DirectoryInfo (dir);

			FileInfo[] fli = dri.GetFiles ();

			foreach (FileInfo fl in fli) {
				if (fl.Extension == ext) {
					fl.CopyTo (@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOFiles\"+fl.Name);
				}
			}

			Directory.Move (@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOFiles", @"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect\KIOFiles");
		}

		/*public static void archive()
		{
			ZipFile.CreateFromDirectory(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect", @"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect.zip");
			ZipFile.ExtractToDirectory(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOInspect.zip", @"C:\Users\Илья\Desktop\Новая папка\OOP\labs\KIOInspect");
		}*/
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Thread thread = new Thread(KIOLog.Start);
			thread.Start();
			Console.WriteLine ("Hello World!");

			//работа класса KIODiskInfo
			KIODiskInfo.freeplace(@"C:\");
			KIODiskInfo.infoflsystem (@"C:\");
			KIODiskInfo.infoforeachdisk ();

			//работа класса KIOFileinfo
			KIOFileinfo.path(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\Новый текстовый документ.txt");
			KIOFileinfo.size_name(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\Новый текстовый документ.txt");
			KIOFileinfo.cratetime(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\Новый текстовый документ.txt");

			//работа класса KIODirInfo
			KIODirInfo.filescount(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs");
			KIODirInfo.createtime(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs");
			KIODirInfo.countsubdir(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs");
			KIODirInfo.listofparentdir(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs");

			//работа класса KIOFileManager
			KIOFileManager.check(@"E:\");
			KIOFileManager.copy(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN", ".asd");

			thread.Abort ();


			using (StreamReader sr = new StreamReader(@"C:\Users\Илья\Desktop\Новая папка\OOP\labs\lab13_XAMARIN\KIOLogfile.txt"))
			{
				string str;
				while (!sr.EndOfStream)
				{
					str = sr.ReadLine ();
					if (str.StartsWith("19.12.2018"))
					{
						Console.WriteLine(str);
					}
				}
			}
	
			Console.ReadKey ();
		}
	}
}
