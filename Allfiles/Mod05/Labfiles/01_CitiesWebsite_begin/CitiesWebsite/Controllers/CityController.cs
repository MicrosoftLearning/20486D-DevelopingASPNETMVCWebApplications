using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CitiesWebsite.Controllers
{
    public class CityController : Controller
    {
        public CityController()
        {

        }

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