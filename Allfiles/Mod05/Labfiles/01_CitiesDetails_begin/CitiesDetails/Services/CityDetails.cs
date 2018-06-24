using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesDetails.Services
{
    public class CityDetails
    {
        public string Country { get; }
        public string Name { get; }
        public string TimeZone { get; }
        public CityPopulation CityPopulation { get; }

        public CityDetails(string country, string cityName, string timeZone, CityPopulation cityPopulation)
        {

        }
    }
}
