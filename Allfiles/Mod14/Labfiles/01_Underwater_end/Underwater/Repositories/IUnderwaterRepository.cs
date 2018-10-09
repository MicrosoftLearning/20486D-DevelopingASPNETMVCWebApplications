using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underwater.Models;

namespace Underwater.Repositories
{
    public interface IUnderwaterRepository
    {
        IEnumerable<Fish> Getfishes();
        Fish GetFishById(int id);
        void AddFish(Fish fish);
        void RemoveFish(int id);
        void SaveChanges();
        IQueryable<Aquarium> PopulateAquariumsDropDownList();
    }
}
