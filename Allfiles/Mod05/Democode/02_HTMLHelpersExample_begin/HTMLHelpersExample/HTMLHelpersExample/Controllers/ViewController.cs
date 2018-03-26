using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HTMLHelpersExample.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DifferentControllerAction()
        {
            return View();
        }
        
        public IActionResult ChangedPath()
        {
            return View();
        }
    }
}