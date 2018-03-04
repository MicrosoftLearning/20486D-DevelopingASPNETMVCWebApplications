using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldJourney.Models
{
    public interface IData
    {
        List<HistoricalSite> HistoricalSiteList { get; set; }
        List<HistoricalSite> HistoricalSiteInitializeData();
        HistoricalSite GetHistoricalSiteById(int? id);
    }
}
