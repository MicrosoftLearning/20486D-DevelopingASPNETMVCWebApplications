using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Models
{
    public class Data : IData
    {   
        public List<HistoricalSite> HistoricalSiteList { get; set; }
        //Initialize Historical Site list
        public List<HistoricalSite> HistoricalSiteInitializeData()
        {
            HistoricalSiteList = new List<HistoricalSite>()
            {
                new HistoricalSite(){ID = 1,SiteName = "Sagrada Familia",Country = "Spain",InterestingFacts = "In the site tour we were told that at the beginning of the building, The historical site had a school for the construction worker's children. It took over a century to build up this historical site. ",ImageName = "Spain.jpg",ImageMimeType = "image/jpeg"},
                new HistoricalSite(){ID = 2,SiteName = "Notre-Dame",Country = "Paris",InterestingFacts = "In the site tour we were told that the historical site visited by millions of people making it one of the most popular site.  ", ImageName = "Paris.jpg",ImageMimeType = "image/jpeg"},
                new HistoricalSite(){ID = 3,SiteName = "St David",Country = "Wales",InterestingFacts = "In the site tour we were told that St David is the smallest site in the UK. ", ImageName = "Wales.jpg", ImageMimeType = "image/jpeg"}
            };
            return HistoricalSiteList;
        }
        //Get HistoricalSite by given id
        public HistoricalSite GetHistoricalSiteById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return HistoricalSiteList.SingleOrDefault(a => a.ID == id);
            }
        }
    }
}
