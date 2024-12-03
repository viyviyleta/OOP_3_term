using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp14
{
    public static class RepeatingTask
        {
        private static Timer timer;
        private static int countdownValue;

        public static void StartCountdown(int seconds)
        {
            countdownValue = seconds;
            timer = new Timer(Countdown, null, 0, 1000);
            Console.WriteLine($"Обратный отсчет начался с {countdownValue} секунд. Нажмите Enter, чтобы остановить.");
            Console.ReadLine();
            timer.Dispose();
        }

        private static void Countdown(object state)
        {
            if (countdownValue > 0)
            {
                Console.WriteLine(countdownValue);
                countdownValue--;
            }
            else
            {
                Console.WriteLine("Обратный отсчет завершен!");
                timer.Dispose();
            }
        }
    }
}