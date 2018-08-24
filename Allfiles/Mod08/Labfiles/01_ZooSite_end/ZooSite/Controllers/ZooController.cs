using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ZooSite.Data;
using ZooSite.Models;

namespace ZooSite.Controllers
{
    public class ZooController : Controller
    {
        private ZooContext _context;
        private IHostingEnvironment _environment;

        public ZooController(ZooContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_context.Photos.ToList());
        }

        public IActionResult VisitorDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BuyTickets()
        {
            return View();
        }

        [HttpPost, ActionName("BuyTickets")]
        public IActionResult BuyTicketsPost(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("ThankYou");
            }
            return View(customer);
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult GetImage(int photoId)
        {
            Photo requestedPhoto = _context.Photos.FirstOrDefault(p => p.PhotoID == photoId);
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