using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricStore.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStore.Controllers
{
    public class StoreSaleController : Controller
    {
        private StoreContext _context;
        private IHostingEnvironment _environment;

        public StoreSaleController(StoreContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
    }
}