using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CitiesDetails.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string city)
        {
            return View((object)city);
        }

        public IActionResult GetImage(string cityName)
        {
            return File($@"\images\{cityName.ToLower()}.jpg", "image/jpeg");
        }
    }
}