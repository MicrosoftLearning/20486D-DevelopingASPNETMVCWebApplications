using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesDetails.Services
{
    public class CityProvider : ICityProvider
    {
        Dictionary<string, CityDetails> _cityList;

        public CityDetails this[string name]
        {
            get
            {
                return _cityList[name];
            }
        }

        public CityProvider()
        {
        }

        private Dictionary<string, CityDetails> CityInitializer()
        {
            Dictionary<string, CityDetails> _cityList = new Dictionary<string, CityDetails>();
            _cityList.Add("Madrid", new CityDetails("Spain", "Madrid", "UTC +1 (Summer +2)", new CityPopulation(2015, 3141991, 6240000, 6529700)));
            _cityList.Add("London", new CityDetails("England", "London", "UTC +0 (Summer +1)", new CityPopulation(2016, 8787892, 9787426, 14040163)));
            _cityList.Add("Paris", new CityDetails("France", "Paris", "UTC +1 (Summer +2)", new CityPopulation(2015, 2206488, 10601122, 12405426)));
            return _cityList;
        }

    }
}
