using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace StateExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? overallVisitsNumber = HttpContext.Session.GetInt32("Overall");
            int? controllerVisitsNumber = HttpContext.Session.GetInt32("Home");
            int? AnotherControllerVisitsNumber = HttpContext.Session.GetInt32("Another");
            if (overallVisitsNumber == null)
            {
                overallVisitsNumber = 1;
            }
            else
            {
                overallVisitsNumber++;
            }
            if (controllerVisitsNumber == null)
            {
                controllerVisitsNumber = 1;
            }
            else
            {
                controllerVisitsNumber++;
            }
            if (AnotherControllerVisitsNumber == null)
            {
                AnotherControllerVisitsNumber = 0;
            }
            HttpContext.Session.SetInt32("Overall", overallVisitsNumber.Value);
            HttpContext.Session.SetInt32("Home", controllerVisitsNumber.Value);
            HttpContext.Session.SetInt32("Another", AnotherControllerVisitsNumber.Value);
            return View();
        }
    }
}