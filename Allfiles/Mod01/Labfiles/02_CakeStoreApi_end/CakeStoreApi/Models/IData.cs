using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeStoreApi.Models
{
    public interface IData
    {
        List<CakeStore> CakesList { get; set; }
        List<CakeStore> CakesInitializeData();
        CakeStore GetCakeById(int? id);
    }
}
