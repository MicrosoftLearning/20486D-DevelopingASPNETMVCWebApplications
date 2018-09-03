using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Underwater.Data;
using Underwater.Models;

namespace Underwater.Repositories
{
    public class UnderwaterRepository : IUnderwaterRepository
    {
        private UnderwaterContext _context;

        public UnderwaterRepository(UnderwaterContext context)
        {
            _context = context;
        }

        public IEnumerable<Fish> Getfishes()
        {
            return _context.fishes.ToList();
        }

        public Fish GetFishById(int id)
        {
            return _context.fishes.Include(a => a.Aquarium)
                 .SingleOrDefault(f => f.FishId == id);
        }

        public void AddFish(Fish fish)
        {
            if (fish.PhotoAvatar != null && fish.PhotoAvatar.Length > 0)
            {
                fish.ImageMimeType = fish.PhotoAvatar.ContentType;
                fish.ImageName = Path.GetFileName(fish.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    fish.PhotoAvatar.CopyTo(memoryStream);
                    fish.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(fish);
                _context.SaveChanges();
            }
        }

        public void RemoveFish(int id)
        {
            var fish = _context.fishes.SingleOrDefault(f => f.FishId == id);
            _context.fishes.Remove(fish);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<Aquarium> PopulateAquariumsDropDownList()
        {
            var aquariumsQuery = from a in _context.Aquariums
                                orderby a.Name
                                select a;
            return aquariumsQuery;
        }
    }
}
