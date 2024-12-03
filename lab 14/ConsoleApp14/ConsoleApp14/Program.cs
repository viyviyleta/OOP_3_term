using System;

namespace ConsoleApp14
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1. Список всех запущенных процессов.");
            Console.WriteLine("2. Исследование доменов приложений и манипулирование ими.");
            Console.WriteLine("3. Вычисление простых чисел в отдельном потоке.");
            Console.WriteLine("4. Два потока для четных и нечетных чисел.");
            Console.WriteLine("5. Повторение задачи с использованием таймера.");
            Console.WriteLine("0. Выход.");

            while (true)
            {
                Console.WriteLine("Ваш выбор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ProcessManager.ListProcesses();
                        break;
                    case "2":
                        AppDomainManager.ManipulateAppDomain();
                        break;
                    case "3":
                        PrimeCalculator.CalculateInThread();
                        break;
                    case "4":
                        EvenOddThreads.RunThreads();
                        break;
                    case "5":
                        {
                            Console.Write("Введите значение n: ");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out int num))
                            {
                                RepeatingTask.StartCountdown(num);
                            }
                            else
                            {
                                Console.WriteLine("Введите число!");
                            }
                            break;
                        }
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неправильный выбор!");
                        break;
                }
            }
        }
    }
}