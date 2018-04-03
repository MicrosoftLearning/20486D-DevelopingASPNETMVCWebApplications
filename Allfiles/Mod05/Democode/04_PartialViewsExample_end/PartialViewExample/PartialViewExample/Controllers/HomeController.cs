using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PartialViewExample.Controllers
{
    public class HomeController : Controller
    {
        string[] FirstNames = { "Jayden", "Adam", "Fatma", "Victoria", "Ethan", "Martín", "Gabriel", "Alice", "Gift", "Olivia", "Carlos", "Marwa", "Ariel", "Omar", "Maria", "Ben" };
        string[] LastNames = { "Musayev", "David", "Nishimura", "Cortez", "Murphy", "Torres", "García", "Hasan", "Adams", "Martínez", "Mayr", "Huang", "James", "Rogers", "Thomas", "King" };
        string[] CityNames = { "New York", "London", "Paris", "Beijing", "Moscow", "Cairo", "La-Paz", "Tel-Aviv", "Sydney", "Tokyo", "Toronto", "Capetown", "Mombai", "Mexico","Berlin","Madrid" };



        public IActionResult Index()
        {
            Random rnd = new Random();
            ViewBag.Rows = 5;
            ViewBag.Columns = 3;
            ViewBag.People = new List<dynamic>();

            for (int personIndex = 0; personIndex < (ViewBag.Rows * ViewBag.Columns); personIndex++)
            {
                dynamic person = new ExpandoObject();
                person.FirstName = FirstNames[rnd.Next(16)];
                person.LastName = LastNames[rnd.Next(16)];
                person.Address = CityNames[rnd.Next(16)];
                person.Phone = "+" + rnd.Next(100000000, 999999999).ToString();

                ViewBag.People.Add(person);
            }

            return View();
        }


        
    }
}