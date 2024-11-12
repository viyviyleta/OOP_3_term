using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LinqQueries
{
    public static IEnumerable<Airline> GetFlightsToDestination(List<Airline> airlines, string destination)
    {
        return airlines.FindAll(a => a.Destination == destination);
    }

    public static int CountFlightsOnDay(List<Airline> airlines, string daysOfWeek)
    {
        return airlines.Count(a => a.DaysOfWeek.Contains(daysOfWeek));
    }

    public static Airline GetEarlyFlightOnDay(List<Airline> airlines, string daysOfWeek)
    {
        return airlines
            .Where(a => a.DaysOfWeek.Contains(daysOfWeek))
            .OrderBy(a => a.DepartureTime)
            .FirstOrDefault();
    }

    public static Airline GetLatestFlightOnDays(List<Airline> airlines, List<string> days)
    {
        return airlines
            .Where(airlines => airlines.DaysOfWeek.Any(day => days.Contains(day)))
            .OrderByDescending(airline => airline.DepartureTime)
            .FirstOrDefault();
    }

    public static IEnumerable<Airline> GetFlightsSortedByDepartureTime(List<Airline> airlines)
    {
        return airlines.OrderBy(a => a.DepartureTime);
    }

    public static IEnumerable<object> GetFlightsWithDestinationInfo(List<Airline> airlines, List<DestinationInfo> destinationInfos)
    {
        return airlines.Join(
            destinationInfos,
            a => a.Destination,
            b => b.City,
            (a,b) => new {a.FlightNumber, a.Destination, b.Country, a.DepartureTime}
            );
    }
}