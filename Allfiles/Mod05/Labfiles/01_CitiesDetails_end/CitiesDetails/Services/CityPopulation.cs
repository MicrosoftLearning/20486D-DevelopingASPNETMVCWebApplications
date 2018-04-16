using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesDetails.Services
{
    public class CityPopulation
    {
        public int _year;
        public int _city;
        public int _urban;
        public int _metro;

        public CityPopulation(int city, int urban, int metro, int year)
        {
            _year = year;
            _city = city;
            _urban = urban;
            _metro = metro;
        }
    }
}
