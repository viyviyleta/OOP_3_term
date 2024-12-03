using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public static class EvenOddThreads
    {
        private static object lockObject = new object();

        public static void RunThreads()
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            Thread evenThread = new Thread(() => PrintEvenNumbers(n));
            Thread oddThread = new Thread(() => PrintOddNumbers(n));

            evenThread.Priority = ThreadPriority.Highest;
            oddThread.Priority = ThreadPriority.Lowest;

            oddThread.Start();
            oddThread.Join();
            evenThread.Start();
            evenThread.Join();





        }

        private static void PrintEvenNumbers(int n)
        {
            using (StreamWriter writer = new StreamWriter("D:\\3 семестр\\OOP\\lab 14\\ConsoleApp14\\ConsoleApp14\\even.txt"))
            {
                for (int i = 2; i <= n; i += 2)
                {
                    lock (lockObject)
                    {
                        writer.WriteLine(i);
                        Console.WriteLine(i);
                    }
                    Thread.Sleep(50);
                }
            }
        }

        private static void PrintOddNumbers(int n)
        {
            using (StreamWriter writer = new StreamWriter("D:\\3 семестр\\OOP\\lab 14\\ConsoleApp14\\ConsoleApp14\\odd.txt"))
            {
                for (int i = 1; i <= n; i += 2)
                {
                    lock (lockObject)
                    {
                        writer.WriteLine(i);
                        Console.WriteLine(i);
                    }
                    Thread.Sleep(100);
                }
            }
        }
    }
}
