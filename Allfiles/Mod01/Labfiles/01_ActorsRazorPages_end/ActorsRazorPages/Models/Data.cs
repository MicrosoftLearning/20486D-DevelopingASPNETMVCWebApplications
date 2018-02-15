using System.Collections.Generic;
using System.Linq;

namespace ActorsRazorPages.Models
{
    //This class is used during development to make sure that ther is data to display
    public class Data : IData
    {
        public List<Actor> ActorsList { get; set; }

        //Initialize actors list
        public List<Actor> ActorsInitializeData()
        {
            ActorsList = new List<Actor>()
            {
                new Actor(){Id = 1,FirstName="Kelly",LastName="Bailey" ,KnownFor="Kelly",OscarWinner=true,ImageName="path.JPG"},
                new Actor(){Id = 2,FirstName ="Pauline ",LastName="Tapia" ,KnownFor="Pauline",OscarWinner=true,ImageName="path.JPG"}
            };

            return ActorsList;
        }

        //Get actor by id
        public Actor GetActorById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return ActorsList.SingleOrDefault(a => a.Id == id);
            }
        }
    }
}
