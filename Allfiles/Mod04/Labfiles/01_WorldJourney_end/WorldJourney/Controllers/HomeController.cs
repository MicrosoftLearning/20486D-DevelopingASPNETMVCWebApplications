using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorldJourney.Controllers
{
    public class HomeController : Controller
    {
        //This action redirects to the Index action in the HistoricalSiteController
        public IActionResult Index()
        {
            return RedirectToAction("Index", "HistoricalSite");
        }
    }
}