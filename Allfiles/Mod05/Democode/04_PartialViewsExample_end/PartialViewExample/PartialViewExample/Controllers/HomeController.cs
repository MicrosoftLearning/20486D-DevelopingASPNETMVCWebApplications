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

        public IActionResult Index()
        {
            ViewBag.People = new List<dynamic>();

            for (int i = 0; i < 15; i++)
            {
                dynamic person = new ExpandoObject();
                person.FirstName = "Dolev" + i;
                person.LastName = "Shapira" + i;
                person.Address = "Ana Frank 6 Holon" + i;
                person.Phone = "054201050" + i;

                ViewBag.People.Add(person);
            }

            return View();
        }


        
    }
}