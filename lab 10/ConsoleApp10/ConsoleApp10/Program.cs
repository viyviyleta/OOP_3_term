using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Programm
{
    public static void Main()
    {
        string[] months = { "January", "February", "March", "April", "May", "June",
                            "July", "August", "September", "October", "November", "December" };
        Console.WriteLine("--------------------1-----------------------");
        int length = 4;
        var monthsWithLengthN = months.Where(month => month.Length == length);
        Console.WriteLine($"Месяцы с длиной строки {length}: {string.Join(", ", monthsWithLengthN)}");

        Console.WriteLine("\n--------------------2-----------------------");
        var summerAndWinterMonths = months.Where(month =>
        month == "December" || month == "January" || month == "February" || 
        month == "June" || month == "July" || month == "August").OrderBy(months => months); 

        Console.WriteLine($"Летние и зимние месяцы: {string.Join(", ", summerAndWinterMonths)}");

        Console.WriteLine("\n--------------------3-----------------------");
        IEnumerable<string> monthsInAlphabeticalOrder = months.OrderBy(month => month);
        Console.WriteLine($"Месяцы в алфавитном порядке: {string.Join(", ", monthsInAlphabeticalOrder)}");

        Console.WriteLine("\n--------------------4-----------------------");

        IEnumerable<string> monthsWithUAndLengthAtLeast4 =
            from month in months
            where month.Contains('u') && month.Length >= 4
            select month;

        Console.WriteLine($"Месяцы, содержащие букву 'u' и длиной не менее 4-х: {string.Join(", ", monthsWithUAndLengthAtLeast4)}");

        //--------------------------------Основоне задание (Варианрт №2)-----------------------------------------------//

        List<Airline> airlines = new List<Airline>
        {
            new Airline("New York", 101, new TimeSpan(8, 30, 0), new List<string> { "Понедельник", "Среда", "Пятница", "Суббота" }),
            new Airline("London", 202, new TimeSpan(12, 0, 0), new List<string> { "Вторник", "Четверг", "Суббота" }),
            new Airline("Paris", 303, new TimeSpan(14, 45, 0), new List<string> { "Понедельник", "Пятница", "Суббота" }),
            new Airline("Berlin", 404, new TimeSpan(10, 15, 0), new List<string> { "Средв", "Суббота" }),
            new Airline("New York", 505, new TimeSpan(6, 0, 0), new List<string> { "Понедельник", "Четверг", "Воскресенье", "Суббота" }),
            new Airline("Berlin", 606, new TimeSpan(22, 0, 0), new List<string> { "Воскресенье", "Суббота" }),
            new Airline("New York", 707, new TimeSpan(19, 30, 0), new List<string> { "Вторник", "Четверг" }),
            new Airline("Berlin", 808, new TimeSpan(17, 15, 0), new List<string> { "Среда", "Суббота" }),
            new Airline("Berlin", 909, new TimeSpan(15, 0, 0), new List<string> { "Пятница", "Суббота" }),
            new Airline("New York", 1010, new TimeSpan(9, 45, 0), new List<string> { "Суббота", "Воскресенье", "Суббота" })
        };

        List<DestinationInfo> destinationInfos = new List<DestinationInfo>
        {
            new DestinationInfo("New York", "USA"),
            new DestinationInfo("London", "UK"),
            new DestinationInfo("Paris", "France")
        };

        Console.WriteLine("\n---------------Пять операция---------------------------\n");
        var fiveOperation = airlines.Take(5).Concat(airlines.Skip(9))
            .OrderBy(airlines => airlines.DepartureTime)
            .Where(c => c.Destination.Equals("New York"))
            .Count(b => b.FlightNumber >= 202);

        Console.WriteLine(fiveOperation);

        Console.WriteLine("\n---------------Первый рейс---------------------------\n");

        var FirstFlights = airlines.First();
        Console.WriteLine(FirstFlights);

        Console.WriteLine("\n---------------Все рейсы в какой-то город----------------------------");
        var flightsToBerlin = LinqQueries.GetFlightsToDestination(airlines, "Berlin");

        Console.WriteLine("Все рейсы в Берлин:");
        foreach (var flight in flightsToBerlin)
        {
            Console.WriteLine(flight);
        }

        Console.WriteLine("\n----------------Количество рейсов---------------------------");
        var mondayFlightsCount = LinqQueries.CountFlightsOnDay(airlines, "Понедельник");
        Console.WriteLine($"\nКоличество рейсов по понедельникам: {mondayFlightsCount}");

        Console.WriteLine("\n-------------------------------------------");
        var latestMonday = LinqQueries.GetEarlyFlightOnDay(airlines, "Понедельник");
        Console.WriteLine($"\nРейс, который вылетает в понедельник раньше всех: {latestMonday}");

        Console.WriteLine("\n-------------------------------------------");
        var latestWedOrFriFlight = LinqQueries.GetLatestFlightOnDays(airlines, new List<string> { "Среда", "Пятница" });
        Console.WriteLine($"\nРейс, который вылетает в среду или пятницу позже всех: {latestWedOrFriFlight}");

        Console.WriteLine("\n------------------Сортировка по времени вылета-------------------------");
        var flightsSortedByTime = LinqQueries.GetFlightsSortedByDepartureTime(airlines);
        Console.WriteLine("\nРейсы, упорядоченные по времени вылета:");
        foreach (var flight in flightsSortedByTime)
        {
            Console.WriteLine(flight);
        }

        Console.WriteLine("\n----------------Объединение двух классов---------------------------\n");
        var flightsWithDestinationInfo = LinqQueries.GetFlightsWithDestinationInfo(airlines, destinationInfos);
        foreach (var info in flightsWithDestinationInfo)
        {
            Console.WriteLine(info);
        }
    }
}