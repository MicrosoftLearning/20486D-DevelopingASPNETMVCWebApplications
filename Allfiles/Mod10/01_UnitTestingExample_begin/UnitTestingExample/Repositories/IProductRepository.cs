using System.Collections.Generic;
using UnitTestingExample.Models;

namespace UnitTestingExample.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}