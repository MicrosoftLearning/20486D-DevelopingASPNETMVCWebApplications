using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PersonContext context)
        {
            context.Database.EnsureCreated();
            if (context.People.Any())
            {
                return;
            }

            var people = new Person[]
            {
            new Person { FirstName = "Tara", LastName = "Brewer", City = "Ocala", Address = "317 Long Street" },
            new Person { FirstName = "Andrew", LastName = "Tippett", City = "Anaheim", Address = "3163 Nickel Road" }
            };

            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
        }
    }
}
