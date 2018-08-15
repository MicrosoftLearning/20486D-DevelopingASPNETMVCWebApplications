using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Data;

namespace ShirtStoreWebsite.Services
{
    public class ShirtRepository : IShirtRepository
    {
        private ShirtContext _context;

        public ShirtRepository(ShirtContext context)
        {
            _context = context;
        }

        public IEnumerable<Shirt> GetShirts()
        {
            return _context.Shirts.ToList();
        }

        public bool AddShirt(Shirt shirt)
        {
            _context.Add(shirt);
            int entries = _context.SaveChanges();
            if(entries > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool RemoveShirt(int id)
        {
            var shirt = _context.Shirts.SingleOrDefault(m => m.Id == id);
            _context.Shirts.Remove(shirt);
            int entries = _context.SaveChanges();
            if (entries > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
