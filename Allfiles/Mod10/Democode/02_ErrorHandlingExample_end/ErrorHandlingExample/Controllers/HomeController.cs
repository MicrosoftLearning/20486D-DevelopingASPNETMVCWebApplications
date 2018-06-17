using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorHandlingExample.Models;
using ErrorHandlingExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ErrorHandlingExample.Controllers
{
    public class HomeController : Controller
    {
        IDivisionCalculator _numberCalculator;
        ICounter _counter;
        ILogger _logger;

        public HomeController(IDivisionCalculator numberCalculator, ICounter cnt, ILogger logger)
        {
            _counter = cnt;
            _numberCalculator = numberCalculator;
            _logger = logger;
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
                _counter.IncrementRequestPathCount(id.ToString());
                ViewBag.ViewAmount = _counter.UrlCounter[id.ToString()];
                ViewBag.CounterSucceeded = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error received while trying to increment or retrieve the value of the counter service. Number value is: {id}");
            }
            DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
            return View(divisionResult);
        }
    }
}