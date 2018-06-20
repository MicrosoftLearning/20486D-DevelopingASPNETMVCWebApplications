using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsWebsite.Models;

namespace ProductsWebsite.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
