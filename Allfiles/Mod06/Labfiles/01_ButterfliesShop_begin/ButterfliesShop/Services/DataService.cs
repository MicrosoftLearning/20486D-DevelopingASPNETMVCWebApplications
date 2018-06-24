using ButterfliesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Services
{
    public class DataService : IDataService
    {
        public List<Butterfly> ButterfliesList { get; set; }
        public void AddButterfly(Butterfly butterfly)
        {
            ButterfliesList.Add(butterfly);
        }

        public List<Butterfly> ButterfliesInitializeData()
        {
            ButterfliesList = new List<Butterfly>()
            {
                new Butterfly(){Id = 1, CommonName = "Blue Morpho Butterfly", ButterflyFamily = Family.Nymphalidae, Quantity = 5, Characteristics = "The blue morpho butterfly are approximately 10 cm wide.", CreatedDate = DateTime.Now, ImageMimeType = "image/jpeg", ImageName = "blue-monarch-butterfly.jpg"},
                new Butterfly(){Id = 2, CommonName = "Menelaus Blue Morpho", ButterflyFamily = Family.Nymphalidae, Quantity = 15,Characteristics = "The blue morpho's wings appears blue but in reality, it is actually caused by the way light reflects on the microscopic scales of the butterfly wings.", CreatedDate = DateTime.Now, ImageMimeType = "image/jpeg", ImageName = "light-blue-butterfly.jpg"},
                new Butterfly(){Id = 3, CommonName = "Purple White Admiral", ButterflyFamily = Family.Nymphalidae, Quantity = 20, Characteristics = "This is a lowland specie, also flights are short in duration. flying only about 2 to 3 feet off the ground.", CreatedDate = DateTime.Now, ImageMimeType = "image/jpeg", ImageName = "unique-butterfly.jpg"},
                new Butterfly(){Id = 4, CommonName = "Indian White Tiger", ButterflyFamily = Family.Danaine, Quantity = 10,Characteristics = "The indian white tiger is a lowland species habitats at elevations below 500m.", CreatedDate = DateTime.Now, ImageMimeType = "image/jpeg", ImageName = "white-tiger.jpg"}
            };
            return ButterfliesList;
        }

        public Butterfly GetButterflyById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return ButterfliesList.SingleOrDefault(a => a.Id == id);
            }
        }
    }
}
