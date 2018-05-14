using System.Collections.Generic;

namespace AnimalsMvc.Models
{
    public interface IData
    {
        List<Animal> AnimalsList { get; set; }
        List<Animal> AnimalsInitializeData();
        Animal GetAnimalById(int? id);
    }
}
