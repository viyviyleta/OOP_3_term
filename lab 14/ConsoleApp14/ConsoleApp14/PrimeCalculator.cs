using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public static class PrimeCalculator
    {
        private static Thread primeThread;
        private static bool isPaused = false;

        public static void CalculateInThread()
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            primeThread = new Thread(() => CalculatePrimes(n));
            primeThread.Start();

            Thread.Sleep(0);
            PauseThread();
            Thread.Sleep(2000);
            ResumeThread();

            primeThread.Join();
        }

        private static void CalculatePrimes(int n)
        {
            using (StreamWriter writer = new StreamWriter("D:\\3 семестр\\OOP\\lab 14\\ConsoleApp14\\ConsoleApp14\\primes.txt"))
            {
                for (int i = 2; i <= n; i++)
                {
                    if (IsPrime(i))
                    {
                        while (isPaused) Thread.Sleep(100);
                        writer.WriteLine(i);
                        Console.WriteLine(i);
                    }
                }
            }
        }

        private static bool IsPrime(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private static void PauseThread()
        {
            isPaused = true;
            Console.WriteLine("Поток приостановлен.");
        }

        private static void ResumeThread()
        {
            isPaused = false;
            Console.WriteLine("Поток возобновлен.");
        }
    }
}
