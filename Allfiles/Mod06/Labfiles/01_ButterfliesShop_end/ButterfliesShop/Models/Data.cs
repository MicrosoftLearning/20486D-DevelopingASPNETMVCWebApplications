using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterfliesShop.Models
{
    public class Data : IData
    {
        public List<Butterfly> ButterfliesList { get; set; }

        public void AddButterfly(Butterfly butterfly)
        {
            ButterfliesList.Add(butterfly);
        }

        public List<Butterfly> ButterfliesInitializeData()
        {
            ButterfliesList = new List<Butterfly>()
            {
                new Butterfly(){Id = 1, /*CommonName = , ButterflyFamily = , AmountInShop = ,Characteristics = ,*/ CreatedDate = DateTime.Now, ImageMimeType = "image/jpg", PhotoFileName = "blue monarch butterfly.jpg"},
                new Butterfly(){Id = 2, /*CommonName = , ButterflyFamily = , AmountInShop = ,Characteristics = ,*/ CreatedDate = DateTime.Now, ImageMimeType = "image/jpg", PhotoFileName = "light blue butterfly.jpg"},
                new Butterfly(){Id = 3, /*CommonName = , ButterflyFamily = , AmountInShop = ,Characteristics = ,*/ CreatedDate = DateTime.Now, ImageMimeType = "image/jpg", PhotoFileName = "unique butterfly.jpg"},
                new Butterfly(){Id = 4, /*CommonName = , ButterflyFamily = , AmountInShop = ,Characteristics = ,*/ CreatedDate = DateTime.Now, ImageMimeType = "image/jpg", PhotoFileName = "White tiger.jpg"}
            };
            return ButterfliesList;
        }

        public Butterfly GetButterflyById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return ButterfliesList.SingleOrDefault(a => a.Id == id);
            }
        }
    }
}
