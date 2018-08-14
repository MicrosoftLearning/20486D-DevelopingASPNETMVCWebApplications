using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Services
{
    public interface IShirtRepository
    {
        IEnumerable<Shirt> GetShirts();
        bool AddShirt(Shirt shirt);
        bool RemoveShirt(int id);
    }
}
