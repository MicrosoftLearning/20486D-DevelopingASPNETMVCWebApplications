using ButterfliesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Services
{
    public class ButterfliesQuantityService : IButterfliesQuantityService
    {
        public ButterfliesQuantityService()
        {
            if (ButterfliesQuantityDictionary == null)
            {
                ButterfliesQuantityDictionary = new Dictionary<Family, int?>();
            }
        }

        private Dictionary<Family, int?> ButterfliesQuantityDictionary { get; set; }

        public void AddButterfliesQuantityData(Butterfly butterfly)
        {
            if (ButterfliesQuantityDictionary.ContainsKey(butterfly.ButterflyFamily.Value))
            {
                ButterfliesQuantityDictionary[butterfly.ButterflyFamily.Value] += butterfly.Quantity;
            }
            else
            {
                ButterfliesQuantityDictionary.Add(butterfly.ButterflyFamily.Value, butterfly.Quantity);
            }
        }

        public int? GetButterflyFamilyQuantity(Family family)
        {
            int? quantity;
            if (ButterfliesQuantityDictionary.TryGetValue(family, out quantity))
            {
                return quantity;
            }
            else
            {
                ButterfliesQuantityDictionary.Add(family, 0);
            }
            return 0;
        }
    }
}
