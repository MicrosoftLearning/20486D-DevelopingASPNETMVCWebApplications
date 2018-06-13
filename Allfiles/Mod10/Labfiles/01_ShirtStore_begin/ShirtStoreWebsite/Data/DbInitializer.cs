using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShirtContext context)
        {
            context.Database.EnsureCreated();
            if (context.Shirts.Any())
            {
                return;
            }

            var shirts = new Shirt[]
            {
                // seeddddddd
            };

            foreach (Shirt s in shirts)
            {
                context.Shirts.Add(s);
            }
            context.SaveChanges();
        }
    }
}
