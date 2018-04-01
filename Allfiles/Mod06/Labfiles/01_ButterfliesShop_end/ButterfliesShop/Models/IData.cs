using System.Collections.Generic;

namespace ButterfliesShop.Models
{
    public interface IData
    {
        List<Butterfly> ButterfliesList { get; set; }
        List<Butterfly> ButterfliesInitializeData();
        Butterfly GetButterflyById(int? id);
        void AddButterfly(Butterfly butterfly);
    }
}