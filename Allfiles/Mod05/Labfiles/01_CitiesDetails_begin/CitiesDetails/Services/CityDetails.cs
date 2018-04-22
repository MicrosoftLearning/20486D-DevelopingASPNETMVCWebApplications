using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesDetails.Services
{
    public class CityDetails
    {
        public string _country;
        public string _city;
        public string _timeZone;
        public CityPopulation _cityPopulation;

        public CityDetails(string country, string city, string timeZone, CityPopulation cityPopulation)
        {

        }
    }
}
