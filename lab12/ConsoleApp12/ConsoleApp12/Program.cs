using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*****************************************************************************************************");
                BVSDiskInfo.WriteDiskInfo("D:\\");
                BVSLog.WriteInLog("BVSDiskInfo.getFreeDrivesSpace()");

                Console.WriteLine("******************************************************************************************************");
                BVSFileInfo.WriteFileInfo(@"D:\3семестр\OOP\lab12\12_Потоки_файловая система.pdf");
                BVSLog.WriteInLog("BVSFileInfo.WriteFileInfo()", "BVSLogfile.txt", @"D:\3семестр\OOP\lab12\BVSLogfile.txt");

                Console.WriteLine("******************************************************************************************************");
                BVSDirInfo.WriteDirInfo(@"D:\3семестр\OOP");
                BVSLog.WriteInLog("BVSDirInfo.WriteDirInfo()", @"D:\3семестр\OOP");

                BVSFileManager.InspectDriver("D:\\");
                BVSLog.WriteInLog("BVSFileManager.InspectDriver()", "D:\\");
                BVSFileManager.CopyFiles(@"D:\3семестр\OOP\Лекции", ".docx");
                BVSLog.WriteInLog("BVSFileManager.CopyFiles()", @"D:\3семестр\OOP\Лекции");
                Console.WriteLine("******************************************************************************************************");
                BVSFileManager.CreateArchive(@"D:\3семестр\OOP\lab12\ConsoleApp12\ConsoleApp12\ForArchive");
                BVSLog.WriteInLog("BVSFileManager.CreateArchive()");

                BVSLog.FindInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
