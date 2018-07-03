using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cupcakes.Controllers
{
    public class CupcakeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImage(int id)
        {
            Cupcake requestedcupcake = _repository.GetCupcakeById(id);
            if (requestedcupcake != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedcupcake.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedcupcake.ImageMimeType);
                }
                else
                {
                    if (requestedcupcake.PhotoFile.Length > 0)
                    {
                        return File(requestedcupcake.PhotoFile, requestedcupcake.ImageMimeType);
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