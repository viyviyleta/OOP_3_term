using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Airline
{
    public string Destination { get; set; }
    public int FlightNumber { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public List<string> DaysOfWeek { get; set; }

    public Airline(string destination, int flightNumber, TimeSpan departureTime, List<string> daysOfWeek)
    {
        Destination = destination;
        FlightNumber = flightNumber;
        DepartureTime = departureTime;
        DaysOfWeek = daysOfWeek;
    }

    public override string ToString()
    {
        string days = string.Join(", ", DaysOfWeek);
        return $"Рейс: {FlightNumber}, до {Destination}, время отправления: {DepartureTime}, дни отправления: {days}";
    }
}
