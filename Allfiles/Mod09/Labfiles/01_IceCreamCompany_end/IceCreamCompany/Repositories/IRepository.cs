using IceCreamCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamCompany.Repositories
{
    public interface IRepository
    {
        IEnumerable<IceCream> GetIceCreamFlavors();
        IceCream GetIceCreamFlavorById(int id);
        void BuyIceCreamFlavor(Customer customer);
    }
}
