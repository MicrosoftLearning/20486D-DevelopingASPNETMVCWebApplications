using Microsoft.EntityFrameworkCore;

namespace PhotoSharingSample.Models
{
    public class PhotoSharingDB : DbContext
    {
        public PhotoSharingDB(DbContextOptions<PhotoSharingDB> options)
           : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }
    }
}
