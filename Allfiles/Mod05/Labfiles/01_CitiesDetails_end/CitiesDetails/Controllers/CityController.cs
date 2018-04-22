using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitiesDetails.Services;

namespace CitiesDetails.Controllers
{
    public class CityController : Controller
    {
        ICityProvider _cities;

        public CityController(ICityProvider cities)
        {
            _cities = cities;
        }

        public IActionResult ShowCities()
        {
            return View();
        }

        public IActionResult ShowDataForCity(string city)
        {
            ViewBag.City = _cities[city];
            return View();
        }

        public IActionResult GetImage(string cityName)
        {
            return File($@"\images\{cityName}.jpg", "image/jpeg");
        }
    }
}