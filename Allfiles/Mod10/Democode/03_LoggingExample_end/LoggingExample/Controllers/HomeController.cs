using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingExample.Services;
using Microsoft.AspNetCore.Mvc;
using LoggingExample.Models;
using Microsoft.Extensions.Logging;

namespace LoggingExample.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;
        IDivisionCalculator _numberCalculator;

        public HomeController(IDivisionCalculator numberCalculator, ILogger<HomeController> logger)
        {
            _logger = logger;
            _numberCalculator = numberCalculator;
        }

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