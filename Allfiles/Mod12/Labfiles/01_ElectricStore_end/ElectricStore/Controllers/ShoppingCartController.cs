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
    public class ShoppingCartController : Controller
    {
        private StoreContext _context;
        private List<Product> products;
        private SessionStateViewModel sessionModel;

        public ShoppingCartController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerFirstName")) && !string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerProducts")))
            {
                List<int> productsListId = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("CustomerProducts"));
                products = new List<Product>();
                foreach (var item in productsListId)
                {
                    var product = _context.Products.SingleOrDefault(p => p.Id == item);
                    products.Add(product);
                }
                sessionModel = new SessionStateViewModel
                {
                    CustomerName = HttpContext.Session.GetString("CustomerFirstName"),
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