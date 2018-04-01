using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ButterfliesShop.Controllers
{
    public class ButterflyController : Controller
    {
        private IData _data;
        private List<Butterfly> _butterfliesList;
        private IHostingEnvironment _environment;

        public ButterflyController(IData data, IHostingEnvironment environment)
        {
            _data = data;
            _butterfliesList = _data.ButterfliesInitializeData();
            _environment = environment;
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Butterfiles = _butterfliesList;
            return View(indexViewModel);
        }

        public IActionResult GetImage(int id)
        {
            Butterfly requestedButterfly = _data.GetButterflyById(id);
            if (requestedButterfly != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedButterfly.PhotoFileName;
                FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                byte[] fileBytes;
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return File(fileBytes, requestedButterfly.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Butterfly butterfly)
        {
            if (ModelState.IsValid)
            {
                _data.AddButterfly(butterfly);
                return RedirectToAction("Index");
            }
            return View(butterfly);
        }
    }
}