using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PhotoSharingSample.Models;
using System.IO;
using System.Linq;

namespace PhotoSharingSample.Controllers
{
    public class HomeController : Controller
    {
        private PhotoSharingDB _dbContext;
        private IHostingEnvironment _environment;

        public HomeController(PhotoSharingDB dbContext, IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        // GET: /<controller>/ 
        //This action displays all the photos
        public IActionResult Index()
        {
            return View(_dbContext.Photos.ToList());
        }

        //This action gets the photo for a given Photo ID
        public IActionResult GetImage(int PhotoId)
        {
            //Get the right photo
            Photo requestedPhoto = _dbContext.Photos.FirstOrDefault(p => p.PhotoID == PhotoId);
            if (requestedPhoto != null)
            {
                // Get the path that is relative to the route of the web site
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedPhoto.PhotoFileName;

                //Gets byte array for a file at the path specified
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
