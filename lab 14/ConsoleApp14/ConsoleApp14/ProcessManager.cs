using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp14
{
    public static class ProcessManager
    {
        public static void ListProcesses()
        {
            Process[] processes = Process.GetProcesses();
            using (StreamWriter file = new StreamWriter("D:\\3 семестр\\OOP\\lab 14\\ConsoleApp14\\ConsoleApp14\\processes.txt"))
            {
                foreach(Process process in processes)
                {
                    try
                    {
                        file.WriteLine($"ID: {process.Id}, Имя: {process.ProcessName}, Приоритет: {process.BasePriority}, Время начала: {process.StartTime}, Сколько времени использовался: {process.TotalProcessorTime}");
                        Console.WriteLine($"ID: {process.Id}, Имя: {process.ProcessName}, Приоритет: {process.BasePriority}, Время начала: {process.StartTime} Сколько времени использовался: {process.TotalProcessorTime}");
                    }
                    catch(Exception ex)
                    {
                        file.WriteLine($"Процесс {process.Id} ({process.ProcessName}) вызвал ошибку: {ex.Message}");
                        Console.WriteLine($"Не удалось получить подробную информацию о процессе {process.ProcessName}: {ex.Message}");
                    }
                }
            }
        }
    }
}
