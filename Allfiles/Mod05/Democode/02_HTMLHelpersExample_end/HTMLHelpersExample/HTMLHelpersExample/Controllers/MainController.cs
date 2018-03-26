using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Normal()
        {
            return View();
        }
        
        public IActionResult RegularWithParameter(string parameter1, string parameter2)
        {
            return Content($"Parameter1 result: {parameter1} {Environment.NewLine}Parameter2 result: {parameter2}");
        }
    }
}