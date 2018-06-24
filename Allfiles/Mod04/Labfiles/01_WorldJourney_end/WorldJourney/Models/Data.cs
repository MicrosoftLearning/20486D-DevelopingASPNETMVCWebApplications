using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Models
{
    public class Data : IData
    {
        public List<City> CityList { get; set; }

        public List<City> CityInitializeData()
        {
            CityList = new List<City>()
            {
                new City(){ID = 1,CityName = "New York",ImageName = "new-york.jpg",ImageMimeType = "image/jpeg"},
                new City(){ID = 2,CityName = "London",ImageName = "london.jpg",ImageMimeType = "image/jpeg"},
                new City(){ID = 3,CityName = "Chicago",ImageName = "chicago.jpg", ImageMimeType = "image/jpeg"}
            };
            return CityList;
        }

        public City GetCityById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return CityList.SingleOrDefault(a => a.ID == id);
            }
        }
    }
}
