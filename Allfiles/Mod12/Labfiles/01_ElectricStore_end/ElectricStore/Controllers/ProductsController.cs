using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ElectricStore.Data;
using ElectricStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ElectricStore.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext _context;
        private IHostingEnvironment _environment;
        private IMemoryCache _memoryCache;
        private const string PRODUCT_KEY = "Products";

        public ProductsController(StoreContext context, IHostingEnvironment environment, IMemoryCache memoryCache)
        {
            _context = context;
            _environment = environment;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            List<Product> products;
            if (!_memoryCache.TryGetValue(PRODUCT_KEY, out products))
            {
                products = _context.Products.ToList();
                products.Select(c => { c.LoadedFromDatabase = DateTime.Now; return c; }).ToList();
                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions();
                cacheOptions.SetPriority(CacheItemPriority.High);
                cacheOptions.SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _memoryCache.Set(PRODUCT_KEY, products, cacheOptions);
            }
            return View(products);
        }

        public IActionResult GetByCategory(int Id)
        {
            var products = _context.Products.Where(c => c.CategoryId == Id);
            var category = _context.menuCategories.FirstOrDefault(c => c.Id == Id);
            ViewBag.categoryTitle = category.Name;
            return View(products);
        }

        [HttpGet]
        public IActionResult AddToShoppingList()
        {
            PopulateProductsList();
            return View();
        }

        [HttpPost, ActionName("AddToShoppingList")]
        public IActionResult AddToShoppingListPost(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerName")) && string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerProducts")))
                {
                    HttpContext.Session.SetString("CustomerName", customer.FirstName);
                    var serialisedDate = JsonConvert.SerializeObject(customer.SelectedProductsList);
                    HttpContext.Session.SetString("CustomerProducts", serialisedDate);
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateProductsList(customer.SelectedProductsList);
            return View(customer);
        }

        private void PopulateProductsList(int[] selectedProducts = null)
        {
            var products = from p in _context.Products
                           orderby p.ProductName
                           select p;

            ViewBag.ProductsList = new MultiSelectList(products.AsNoTracking(), "Id", "ProductName", selectedProducts);
        }

        public IActionResult GetImage(int productId)
        {
            Product requestedPhoto = _context.Products.SingleOrDefault(i => i.Id == productId);
            if (requestedPhoto != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedPhoto.PhotoFileName;

                FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                byte[] fileBytes;
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return File(fileBytes, requestedPhoto.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }
    }
}