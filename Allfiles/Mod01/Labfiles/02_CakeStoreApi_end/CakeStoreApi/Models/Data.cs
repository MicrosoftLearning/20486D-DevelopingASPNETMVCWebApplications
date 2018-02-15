using System.Collections.Generic;
using System.Linq;

namespace CakeStoreApi.Models
{
    //This class is used during development to make sure that ther is data to display
    public class Data : IData
    {
        public List<CakeStore> CakesList { get; set; }

        //Initialize Cakes list
        public List<CakeStore> CakesInitializeData()
        {
            CakesList = new List<CakeStore>()
            {
                new CakeStore(){Id = 1,CakeType = "BirthdayCake", Quantity = 50},
                new CakeStore(){Id = 2,CakeType = "StrawberryCake",Quantity = 48},
                new CakeStore(){Id = 3,CakeType = "CheesecakeCake",Quantity = 62},
                new CakeStore(){Id = 4, CakeType = "ChocolateCake", Quantity = 68}
            };

            return CakesList;
        }

        //Get Cake by id
        public CakeStore GetCakeById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return CakesList.SingleOrDefault(a => a.Id == id);
            }
        }
    }
}
