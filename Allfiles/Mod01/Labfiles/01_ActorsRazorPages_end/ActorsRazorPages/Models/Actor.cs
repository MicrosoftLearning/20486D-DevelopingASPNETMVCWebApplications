namespace ActorsRazorPages.Models
{
    public class Actor
    {
        //Id. This is the primary key
        public int Id { get; set; }

        //FirstName. This is the actor FirstName
        public string FirstName { get; set; }
 
        //LastName. This is the actor LastName
        public string LastName { get; set; }

        //KnownFor. This is the movie name they are known for
        public string KnownFor { get; set; }

        //OscarWinner. Indicates whether the actor won an Oscar award 
        public bool OscarWinner { get; set; }

        //ImageName. This is the picture name
        public string ImageName { get; set; }
    }
}
