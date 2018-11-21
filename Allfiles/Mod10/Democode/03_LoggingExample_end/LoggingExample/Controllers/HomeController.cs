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
        ILogger _logger;

        public HomeController(IDivisionCalculator numberCalculator, ICounter counter, ILogger<HomeController> logger)
        {
            _counter = counter;
            _numberCalculator = numberCalculator;
            _logger = logger;
        }

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
                _logger.LogError("GetDividedNumber - Success ");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while trying to increase or retrieve the page display count. Number parameter is: {id}");
            }

            DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
            return View(divisionResult);
        }
    }
}