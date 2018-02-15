using System.Collections.Generic;

namespace AnimlasMvc.Models
{
    //This class represents the animal list that is displays in the index view
    public class IndexViewModel
    {
        public List<Animal> Animals { get; set; }
    }
}
