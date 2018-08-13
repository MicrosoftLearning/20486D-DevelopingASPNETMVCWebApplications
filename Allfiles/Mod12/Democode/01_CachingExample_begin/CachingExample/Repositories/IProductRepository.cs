using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CachingExample.Models;

namespace CachingExample.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Dictionary<int, string> GetProductNames();
        Product GetProduct(int id);
    }
}
