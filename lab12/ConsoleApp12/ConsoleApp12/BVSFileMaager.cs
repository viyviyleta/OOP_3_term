using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public static class BVSFileManager
    {
        public static void InspectDriver(string driverName)
        {
            Directory.CreateDirectory(@"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect");
            File.Create(@"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect\BVSdirinfo.txt").Close();
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driverName);

            using (StreamWriter file = new StreamWriter(@"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect\BVSdirinfo.txt"))
            {
                file.WriteLine("Список папок:");
                foreach (var s in currentDrive.RootDirectory.GetDirectories())
                {
                    file.WriteLine(s);
                }
                file.WriteLine("Список файлов:");
                foreach (var f in currentDrive.RootDirectory.GetFiles())
                {
                    file.WriteLine(f);
                }
            }

            File.Copy(@"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect\BVSdirinfo.txt", @"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect\BVSdirinfoCopy.txt", true);
            File.Delete(@"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect\BVSdirinfo.txt");
        }

        public static void CopyFiles(string path, string extention)
        {
            string targetPath = @"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSFiles";
            Directory.CreateDirectory(targetPath);

            DirectoryInfo sourceDir = new DirectoryInfo(path);

            foreach (var file in sourceDir.GetFiles())
            {
                if (file.Extension.Equals(extention, StringComparison.OrdinalIgnoreCase))
                {
                    file.CopyTo(Path.Combine(targetPath, file.Name), true);
                }
            }

            string inspectPath = @"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect\BVSFiles";
            if (Directory.Exists(targetPath))
            {
                if (Directory.Exists(inspectPath))
                {
                    Directory.Delete(inspectPath, true);
                }
                Directory.Move(targetPath, inspectPath);
            }
        }

        public static void CreateArchive(string dir)
        {
            string name = @"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\BVSInspect\BVSFiles\";
            string archivePath = name.TrimEnd('\\') + ".zip"; 

            if (!File.Exists(archivePath))
            {
                ZipFile.CreateFromDirectory(name, archivePath);
                Console.WriteLine($"Архив создан: {archivePath}");
            }
            else
            {
                Console.WriteLine($"Архив уже существует: {archivePath}");
            }

            if (Directory.Exists(dir))
            {
                ZipFile.ExtractToDirectory(archivePath, dir, overwriteFiles: true);
                Console.WriteLine($"Файлы извлечены в папку: {dir}");
            }
        }
    }
}