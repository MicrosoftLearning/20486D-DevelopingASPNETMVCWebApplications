using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using CitiesWebsite.Models;

namespace CitiesWebsite.Services
{
    public class CityProvider : ICityProvider
    {
        Dictionary<string, City> _cities;

        public CityProvider()
        {

        }

        public City this[string name]
        {
            get
            {
                return _cities[name];
            }
        }

        private Dictionary<string, City> CityInitializer()
        {
            Dictionary<string, City> _cityList = new Dictionary<string, City>();
            _cityList.Add("Madrid", new City("Spain", "Madrid", "UTC +1 (Summer +2)", new CityPopulation(2015, 3141991, 6240000, 6529700)));
            _cityList.Add("London", new City("England", "London", "UTC +0 (Summer +1)", new CityPopulation(2016, 8787892, 9787426, 14040163)));
            _cityList.Add("Paris", new City("France", "Paris", "UTC +1 (Summer +2)", new CityPopulation(2015, 2206488, 10601122, 12405426)));
            return _cityList;
        }

        public IEnumerator<KeyValuePair<string, City>> GetEnumerator()
        {
            return _cities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cities.GetEnumerator();
        }
    }
}
