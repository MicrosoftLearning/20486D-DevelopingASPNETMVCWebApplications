using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CitiesDetails.Controllers
{
    public class CityController : Controller
    {
        public IActionResult ShowCities()
        {
            return View();
        }

        public IActionResult ShowDataForCity()
        {
            return View();
        }

        public IActionResult GetImage(string cityName)
        {
            return Content(cityName);
        }
    }
}