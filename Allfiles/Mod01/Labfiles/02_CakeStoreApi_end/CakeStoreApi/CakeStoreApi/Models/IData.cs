using System.Collections.Generic;

namespace CakeStoreApi.Models
{
    public interface IData
    {
        List<CakeStore> CakesList { get; set; }
        List<CakeStore> CakesInitializeData();
        CakeStore GetCakeById(int? id);
    }
}
