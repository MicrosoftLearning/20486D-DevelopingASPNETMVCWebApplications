using System.Collections.Generic;
using System.Linq;

namespace AnimlasMvc.Models
{
    //This class is used during development to make sure that there is data to display
    public class Data : IData
    {
        public List<Animal> AnimalsList { get; set; }

        //Initialize actors list
        public List<Animal> AnimalsInitializeData()
        {
            AnimalsList = new List<Animal>()
            {
                new Animal(){
                    Id = 1,
                    Name = "Lion",
                    Category = "Mammal",
                    UniqueInformation = "white lions do exist, in Timbavati, South Africa. There is a recessive gene in white lions that gives them their unusual color.",
                    ImageName = "LionPic.jpg"},
                new Animal(){Id = 2,
                    Name = "Horse",
                    Category = "Mammal",
                    UniqueInformation = "A 2010 study revealed some very surprising results about horse intelligence, especially memory. Not only does our equine friend understand our words far better than we have previously anticipated, its memory is at least as good as that of an elephant.",
                    ImageName = "HorsePic.jpg"},
                new Animal(){Id = 3,
                    Name = "Swan",
                    Category = "Bird",
                    UniqueInformation = "Swans can fly as fast as 60 miles per hour.",
                    ImageName = "SwanPic.jpg"},
                new Animal(){Id = 4,
                    Name = "Octopus",
                    Category = "Fish",
                    UniqueInformation = "Studies have shown that octopuses learn easily, including learning by observation of another octopus.",
                    ImageName = "OctopusPic.jpg"}
            };

            return AnimalsList;
        }

        //Get animal by id
        public Animal GetAnimalById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return AnimalsList.SingleOrDefault(a => a.Id == id);
            }
        }
    }
}
