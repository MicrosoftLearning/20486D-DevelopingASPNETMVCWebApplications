using Cupcakes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CupcakeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cupcakes.Any())
            {
                return;
            }

            var cupcakes = new Cupcake[]
            {

            };

            foreach (Cupcake cupcake in cupcakes)
            {
                context.Cupcakes.Add(cupcake);
            }
            context.SaveChanges();

            var Bakeries = new Bakery[]
            {

            };
            foreach (Bakery bakery in Bakeries)
            {
                context.Bakeries.Add(bakery);
            }
            context.SaveChanges();
        }
    }
}
