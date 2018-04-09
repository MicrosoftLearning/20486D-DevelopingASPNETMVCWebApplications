using System.Collections.Generic;

namespace AnimalMvc.Models
{
    public interface IData
    {
        List<Animal> AnimalsList { get; set; }
        List<Animal> AnimalsInitializeData();
        Animal GetAnimalById(int? id);
    }
}
