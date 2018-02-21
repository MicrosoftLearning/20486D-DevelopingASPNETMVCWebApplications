using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoutesExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id = 50)
        {
            return Content("This is the Home controller with default param: " + id);
        }

        [Route("Hello/{name}/{lastName}")]
        public IActionResult Greeting(string name, string lastName)
        {
            return Content(String.Format("Hello {0}-{1} from module 4 demo 2",name,lastName));
        }
    }
}