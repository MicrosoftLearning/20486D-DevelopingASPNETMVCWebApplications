using ButterfliesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Services
{
    public interface IButterfliesQuantityService
    {
        Dictionary<Family, int> ButterfliesQuantityDictionary { get; set; }
        int GetButterflyFamilyQuantity(Family family);
        void AddButterfliesQuantityData(Butterfly butterfly);
    }
}
