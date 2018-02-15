using Microsoft.EntityFrameworkCore;

namespace PhotoSharingSample.Models
{
    //This class is used to create a connection between entity classes and the database
    public class PhotoSharingDB : DbContext
    {
        public PhotoSharingDB(DbContextOptions<PhotoSharingDB> options)
           : base(options)
        {

        }
        //entity class
        public DbSet<Photo> Photos { get; set; }
    }
}
