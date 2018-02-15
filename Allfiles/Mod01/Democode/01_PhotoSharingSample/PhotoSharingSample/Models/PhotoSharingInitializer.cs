using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoSharingSample.Models
{
    //This class is used during development to insert sample data into the database
    public static class PhotoSharingInitializer
    {
        //This method puts sample data into the database
        public static void Seed(PhotoSharingDB dbContext)
        {
            //creates a database if it does not exist
            dbContext.Database.EnsureCreated();
            if (!dbContext.Photos.Any())
            {
                //Create some photos
                var photos = new List<Photo>
                {
                    new Photo {
                        Title = "Flower",
                        Description = "Cow parsley, photographed in close up.",
                        PhotoFileName = "flower.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    },
                    new Photo {
                        Title = "Orchard",
                        Description = "This was taken on a sunny fall day.",
                        PhotoFileName = "orchard.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    },
                    new Photo {
                        Title = "Blackberries",
                        Description = "This was late for blackberries so they are a little past their best.",
                        PhotoFileName = "blackberries.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    },
                    new Photo {
                        Title = "Ripples",
                        Description = "Interesting reflections and colors in this marine shot.",
                        PhotoFileName = "ripples.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    },
                    new Photo {
                        Title = "View Along a Path",
                        Description = "The light was great through the trees so I had to stop and take this.",
                        PhotoFileName = "path.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    },
                    new Photo {
                        Title = "Headland View",
                        Description = "A beautiful view on a beautiful day.",
                        PhotoFileName = "headland.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    },
                    new Photo {
                        Title = "Fungi",
                        Description = "Found a fugi During a walk in the forest.",
                        PhotoFileName = "fungi.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    },
                    new Photo {
                        Title = "Coastal view",
                        Description = "A view from my vacation in greece.",
                        PhotoFileName = "zakynthos.jpg",
                        ImageMimeType = "image/jpeg",
                        CreatedDate = DateTime.Today
                    }
                };
                //save to database all the photos
                photos.ForEach(p => dbContext.Photos.Add(p));
                dbContext.SaveChanges();
            }
        }
    }
}
