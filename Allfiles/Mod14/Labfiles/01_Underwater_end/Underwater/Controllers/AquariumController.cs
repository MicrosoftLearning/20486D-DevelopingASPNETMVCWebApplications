using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Underwater.Models;
using Underwater.Repositories;

namespace Underwater.Controllers
{
    public class AquariumController : Controller
    {
        private IUnderwaterRepository _repository;
        private IHostingEnvironment _environment;

        public AquariumController(IUnderwaterRepository repository, IHostingEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_repository.Getfishes());
        }

        public IActionResult Details(int id)
        {
            var fish = _repository.GetFishById(id);
            if (fish == null)
            {
                return NotFound();
            }
            return View(fish);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateAquariumsDropDownList();
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(Fish fish)
        {
            if (ModelState.IsValid)
            {
                _repository.AddFish(fish);
                return RedirectToAction(nameof(Index));
            }
            PopulateAquariumsDropDownList(fish.AquariumId);
            return View(fish);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Fish fish = _repository.GetFishById(id);
            if (fish == null)
            {
                return NotFound();
            }
            PopulateAquariumsDropDownList(fish.AquariumId);
            return View(fish);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            var fishToUpdate = _repository.GetFishById(id);
            bool isUpdated = await TryUpdateModelAsync<Fish>(
                                fishToUpdate,
                                "",
                                f => f.AquariumId,
                                f => f.Name,
                                f => f.ScientificName,
                                f => f.CommonName
                               );
            if (isUpdated)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulateAquariumsDropDownList(fishToUpdate.AquariumId);
            return View(fishToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var fish = _repository.GetFishById(id);
            if (fish == null)
            {
                return NotFound();
            }
            return View(fish);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.RemoveFish(id);
            return RedirectToAction(nameof(Index));
        }

        private void PopulateAquariumsDropDownList(int? selectedAquarium = null)
        {
            var aquariums = _repository.PopulateAquariumsDropDownList();
            ViewBag.AquariumID = new SelectList(aquariums.AsNoTracking(), "AquariumId", "Name", selectedAquarium);
        }

        public IActionResult GetImage(int id)
        {
            Fish requestedFish = _repository.GetFishById(id);
            if (requestedFish != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedFish.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedFish.ImageMimeType);
                }
                else
                {
                    if (requestedFish.PhotoFile.Length > 0)
                    {
                        return File(requestedFish.PhotoFile, requestedFish.ImageMimeType);
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