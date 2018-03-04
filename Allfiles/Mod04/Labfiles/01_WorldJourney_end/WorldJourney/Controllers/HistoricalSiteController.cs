using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WorldJourney.Filters;
using WorldJourney.Models;

namespace WorldJourney.Controllers
{
    //Custom routes attribute
    [ServiceFilter(typeof(LogActionFilter))]
    public class HistoricalSiteController : Controller
    {
        private IData _data;
        private IHostingEnvironment _environment;

        public HistoricalSiteController(IData data, IHostingEnvironment environment)
        {
            _data = data;
            _environment = environment;
            _data.HistoricalSiteInitializeData();
        }
    
        public IActionResult Index() 
        {
            return View();
        }
        //This action gets the HistoricalSite information for a given HistoricalSite ID
        public IActionResult Details(int? id)
        {
            var historicalSite = _data.GetHistoricalSiteById(id);
            if (historicalSite == null)
            {
                return NotFound();
            }
            ViewBag.Title = historicalSite.SiteName;
            return View(historicalSite);
        }

        //This action gets the HistoricalSite for a given HistoricalSite ID
        public IActionResult GetImage(int historicalSiteId)
        {
            //Get the right photo
            var requestedSite = _data.GetHistoricalSiteById(historicalSiteId);
            if (requestedSite != null)
            {
                // Get the path that is relative to the route of the web site
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedSite.ImageName;

                //Gets byte array for a file at the path specified
                FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                byte[] fileBytes;
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }
                return File(fileBytes, requestedSite.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }
    }
}