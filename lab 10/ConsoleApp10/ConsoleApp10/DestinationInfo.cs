using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DestinationInfo
{
    public string City { get; set; }
    public string Country { get; set; }

    public DestinationInfo(string city, string country)
    {
        City = city;
        Country = country;
    }
}
