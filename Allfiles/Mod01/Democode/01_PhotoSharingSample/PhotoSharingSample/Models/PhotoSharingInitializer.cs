using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoSharingSample.Models
{
    public static class PhotoSharingInitializer
    {
        public static void Seed(PhotoSharingDB dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Photos.Any())
            {
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
                photos.ForEach(p => dbContext.Photos.Add(p));
                dbContext.SaveChanges();
            }
        }
    }
}
