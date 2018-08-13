using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CachingExample.Data;
using CachingExample.Models;

namespace CachingExample.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            Product product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            return product;
        }

        public Dictionary<int, string> GetProductNames()
        {
            IEnumerable<Product> products = _context.Products.ToList();
            Dictionary<int, string> productNames = new Dictionary<int, string>();
            foreach(Product product in products)
            {
                productNames[product.Id] = product.Name;
            }
            return productNames;
        }
    }
}
