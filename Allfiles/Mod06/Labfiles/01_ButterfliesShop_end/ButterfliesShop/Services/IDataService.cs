using ButterfliesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Services
{
    public interface IDataService
    {
        List<Butterfly> ButterfliesList { get; set; }
        List<Butterfly> ButterfliesInitializeData();
        Butterfly GetButterflyById(int? id);
        void AddButterfly(Butterfly butterfly);
    }
}
