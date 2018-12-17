using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorHandlingExample.Models;
using ErrorHandlingExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;

namespace ErrorHandlingExample.Controllers
{
    public class HomeController : Controller
    {
        IDivisionCalculator _numberCalculator;
        ICounter _counter;

        public HomeController(IDivisionCalculator numberCalculator, ICounter counter)
        {
            _numberCalculator = numberCalculator;
            _counter = counter;
        }

        public IActionResult Index()
        {
            ViewBag.NumberOfViews = _counter.UrlCounter[HttpContext.Request.GetDisplayUrl()];
            return View();
        }

        public IActionResult GetDividedNumber(int id)
        {
            ViewBag.NumberOfViews = _counter.UrlCounter[HttpContext.Request.GetDisplayUrl()];
            DivisionResult divisionResult = _numberCalculator.GetDividedNumbers(id);
            return View(divisionResult);
        }
    }
}