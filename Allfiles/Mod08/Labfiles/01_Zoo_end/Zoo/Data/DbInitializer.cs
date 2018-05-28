using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models;

namespace Zoo.Data
{
    public class DbInitializer
    {
        public static void Initialize(ZooContext context)
        {
            context.Database.EnsureCreated();

            if (context.Photos.Any())
            {
                return;
            }

            var photos = new Photo[]
            {
                new Photo{Title = "Butterfly Garden", Description = "In computing, a code segment, also known as a text segment or simply as text", PhotoFileName = "butterfly.jpg", ImageMimeType = "image/jpeg"},
                new Photo{Title = "African Animals", Description = "In computing, a code segment, also known as a text segment or simply as text", PhotoFileName = "lion.jpg", ImageMimeType = "image/jpeg"},
                new Photo{Title = "Underwater World", Description = "In computing, a code segment, also known as a text segment or simply as text", PhotoFileName = "octopus.jpg", ImageMimeType = "image/jpeg"},
                new Photo{Title = "Sea Birds", Description = "In computing, a code segment, also known as a text segment or simply as text", PhotoFileName = "swan.jpg", ImageMimeType = "image/jpeg"}
            };

            foreach (Photo photo in photos)
            {
                context.Photos.Add(photo);
            }
            context.SaveChanges();
        }
    }
}
