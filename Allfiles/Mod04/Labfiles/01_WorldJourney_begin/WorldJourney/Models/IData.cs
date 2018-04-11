using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Models
{
    public interface IData
    {
        List<City> CityList { get; set; }
        List<City> CityInitializeData();
        City GetCityById(int? id);
    }
}
