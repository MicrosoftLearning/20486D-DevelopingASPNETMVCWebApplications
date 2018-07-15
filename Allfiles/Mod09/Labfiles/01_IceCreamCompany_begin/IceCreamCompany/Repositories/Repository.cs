using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceCreamCompany.Data;
using IceCreamCompany.Models;

namespace IceCreamCompany.Repositories
{
    public class Repository : IRepository
    {
        private IceCreamContext _context;

        public Repository(IceCreamContext context)
        {
            _context = context;
        }

        public void BuyIceCreamFlavor(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public IceCream GetIceCreamFlavorById(int id)
        {
            return _context.IceCreamFlavors.SingleOrDefault(i => i.IceCreamId == id);
        }

        public IEnumerable<IceCream> GetIceCreamFlavors()
        {
            return _context.IceCreamFlavors.ToList();
        }
    }
}
