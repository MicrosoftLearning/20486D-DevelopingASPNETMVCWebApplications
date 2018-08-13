using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesWebsite.Services
{
    public interface ICityFormatter
    {
        string GetFormattedPopulation(int population);
    }
}
