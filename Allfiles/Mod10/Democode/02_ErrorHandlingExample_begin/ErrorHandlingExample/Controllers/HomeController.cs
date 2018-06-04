using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorHandlingExample.Services;
using Microsoft.AspNetCore.Mvc;
using ErrorHandlingExample.Models;

namespace ErrorHandlingExample.Controllers
{
    public class HomeController : Controller
    {
        IPrimalNumberCalculator _numberCalculator;

        public HomeController(IPrimalNumberCalculator numberCalculator)
        {
            _numberCalculator = numberCalculator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetModuluForNumber(int id)
        {
            DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
            return View(divisionResult);
        }
    }
}