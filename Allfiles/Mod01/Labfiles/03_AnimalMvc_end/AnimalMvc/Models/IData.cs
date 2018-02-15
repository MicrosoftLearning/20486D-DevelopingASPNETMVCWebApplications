using System.Collections.Generic;

namespace AnimlasMvc.Models
{
    //This interface is used during development to make sure that there is data to display
    public interface IData
    {
        List<Animal> AnimalsList { get; set; }
        List<Animal> AnimalsInitializeData();
        Animal GetAnimalById(int? id);
    }
}
