using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesWebsite.Models
{
    public class City
    {
        public string Country { get; }
        public string Name { get; }
        public string TimeZone { get; }
        public CityPopulation Population { get; }

        public City(string country, string cityName, string timeZone, CityPopulation population)
        {
            Country = country;
            Name = cityName;
            TimeZone = timeZone;
            Population = population;
        }
    }
}
