using LayoutExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutExample.Data
{
    public class DbInitializer
    {
        public static void Initialize(StudentContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student { FirstName = "Tara", LastName = "Brewer", City = "Ocala", Address = "317 Long Street" ,Birthdate =  new DateTime(1990,05,22),Course = "Accounting & Finance",StartedUniversityDate = new DateTime(2015,10,1)},
                new Student { FirstName = "Andrew", LastName = "Tippett", City = "Anaheim", Address = "3163 Nickel Road" , Birthdate = new DateTime(1992,03,5),Course = "Architecture",StartedUniversityDate = new DateTime(2017,10,1)},
                new Student { FirstName = "Tara", LastName = "Brewer", City = "Ocala", Address = "317 Long Street" ,Birthdate =  new DateTime(1990,05,22),Course = "Accounting & Finance",StartedUniversityDate = new DateTime(2015,10,1)},
                new Student { FirstName = "Tara", LastName = "Brewer", City = "Ocala", Address = "317 Long Street" ,Birthdate =  new DateTime(1990,05,22),Course = "Accounting & Finance",StartedUniversityDate = new DateTime(2015,10,1)},
                new Student { FirstName = "Andrew", LastName = "Tippett", City = "Anaheim", Address = "3163 Nickel Road" , Birthdate = new DateTime(1992,03,5),Course = "Architecture",StartedUniversityDate = new DateTime(2017,10,1)}

            };

            foreach (Student p in students)
            {
                context.Students.Add(p);
            }
            context.SaveChanges();
        }
    }
}
