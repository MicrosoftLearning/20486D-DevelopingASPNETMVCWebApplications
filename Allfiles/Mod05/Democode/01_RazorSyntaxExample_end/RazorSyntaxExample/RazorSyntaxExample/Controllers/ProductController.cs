using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorSyntaxExample.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ProductPrices = new Dictionary<string, int>();
            ViewBag.ProductPrices.Add("Bread", 5);
            ViewBag.ProductPrices.Add("Rice", 3);
            return View();
        }
    }


}
