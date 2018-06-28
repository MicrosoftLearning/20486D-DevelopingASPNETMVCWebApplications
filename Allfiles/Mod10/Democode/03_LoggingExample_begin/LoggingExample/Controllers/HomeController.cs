using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggingExample.Models;
using LoggingExample.Services;
using Microsoft.Extensions.Logging;

namespace LoggingExample.Controllers
{
    public class HomeController : Controller
    {
        IDivisionCalculator _numberCalculator;
        ICounter _counter;

        public HomeController(IDivisionCalculator numberCalculator, ICounter counter)
        {
            _counter = counter;
            _numberCalculator = numberCalculator;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDividedNumber(int id)
        {
            ViewBag.CounterSucceeded = false;

            _counter.IncrementNumberCount(id);
            ViewBag.NumberOfViews = _counter.NumberCounter[id];
            ViewBag.CounterSucceeded = true;

            DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
            return View(divisionResult);
        }
    }
}