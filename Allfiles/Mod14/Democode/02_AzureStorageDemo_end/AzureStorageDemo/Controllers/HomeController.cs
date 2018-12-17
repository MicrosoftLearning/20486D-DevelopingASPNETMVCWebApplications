using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AzureStorageDemo.Data;
using AzureStorageDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AzureStorageDemo.Controllers
{
    public class HomeController : Controller
    {
        private PhotoContext _dbContext;
        private IHostingEnvironment _environment;

        public HomeController(PhotoContext dbContext, IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Photos.ToList());
        }

        public IActionResult GetImage(int id)
        {
            Photo requestedPhoto = _dbContext.Photos.FirstOrDefault(i => i.Id == id);
            if (requestedPhoto != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedPhoto.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
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
                    if (requestedPhoto.PhotoFile.Length > 0)
                    {
                        return File(requestedPhoto.PhotoFile, requestedPhoto.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}