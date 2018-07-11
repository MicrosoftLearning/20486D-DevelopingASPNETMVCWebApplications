using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesWebsite.Services
{
    public class CityFormatter : ICityFormatter
    {
        public string GetFormattedPopulation(int population)
        {
            return string.Format("{0:n0}", population);
        }
    }
}
