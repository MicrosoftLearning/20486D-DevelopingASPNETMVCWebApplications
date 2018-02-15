using System;

namespace AnimlasMvc.Models
{
    public class Animal
    {
        //Id. This is the primary key
        public int Id { get; set; }

        //Name. This is the Animal name
        public string Name { get; set; }

        //Name. This is the Image Name
        public string ImageName { get; set; }

        //Unique Information. This is the Animal Unique Information
        public string UniqueInformation { get; set; }

        //Category. This is the Animal Category
        public String Category { get; set; }
    }
}
