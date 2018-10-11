using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElectricStore.Data;
using ElectricStore.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ElectricStore.Controllers
{
    public class ShoppingCardController : Controller
    {
        private StoreContext _context;
        private List<Product> products;
        private SessionStateViewModel sessionModel;

        public ShoppingCardController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerName")) && !string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerProducts")))
            {
                int[] ProductsListId = JsonConvert.DeserializeObject<int[]>(HttpContext.Session.GetString("CustomerProducts"));
                products = new List<Product>();
                foreach (var item in ProductsListId)
                {
                    var product = _context.Products.SingleOrDefault(p => p.Id == item);
                    products.Add(product);
                }
                sessionModel = new SessionStateViewModel
                {
                    CustomerName = HttpContext.Session.GetString("CustomerName"),
                    SelectedProducts = products
                };
                return View(sessionModel);
            }
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }
    }
}