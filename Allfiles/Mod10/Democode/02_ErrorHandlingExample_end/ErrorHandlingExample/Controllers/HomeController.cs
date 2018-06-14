using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorHandlingExample.Models;
using ErrorHandlingExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingExample.Controllers
{
    public class HomeController : Controller
    {
        IDivisionCalculator _numberCalculator;

        public HomeController(IDivisionCalculator numberCalculator)
        {
            _numberCalculator = numberCalculator;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDividedNumber(int id)
        {
            DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
            return View(divisionResult);
        }
    }
}