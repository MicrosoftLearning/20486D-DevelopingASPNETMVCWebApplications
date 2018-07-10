using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceCreamCompany.Models;

namespace IceCreamCompany.Repositories
{
    public class Repository : IRepository
    {
        public void BuyIceCreamFlavor(IceCream iceCream)
        {
            throw new NotImplementedException();
        }

        public IceCream GetIceCreamFlavorById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IceCream> GetIceCreamFlavors()
        {
            throw new NotImplementedException();
        }

        public IQueryable<IceCream> PopulateIceCreamFlavorsDropDownList()
        {
            throw new NotImplementedException();
        }
    }
}
