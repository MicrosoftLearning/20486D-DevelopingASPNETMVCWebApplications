using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingExample.Models;
using LoggingExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingExample.Controllers
{
    public class HomeController : Controller
    {
        ILogger _logger;
        IDivisionCalculator _numberCalculator;
        ICounter _counter;

        public HomeController(IDivisionCalculator numberCalculator, ICounter counter, ILogger<HomeController> logger)
        {
            _logger = logger;
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
            try
            {
                _counter.IncrementNumberCount(id);
                ViewBag.NumberOfViews = _counter.NumberCounter[id];
                ViewBag.CounterSucceeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while trying to increase or retrieve the time the page was viewed. Number parameter is: {id}");
            }

            DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
            return View(divisionResult);
        }
    }
}