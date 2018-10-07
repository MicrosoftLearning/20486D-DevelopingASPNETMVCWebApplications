using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElectricStore.Data;
using ElectricStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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