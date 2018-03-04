using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Models
{
    public class HistoricalSite
    {
        public int ID { get; set; }
        public string SiteName { get; set; }
        public string Country { get; set; }
        public string InterestingFacts { get; set; }
        public string ImageName { get; set; }
        public string ImageMimeType { get; set; }
    }
}
