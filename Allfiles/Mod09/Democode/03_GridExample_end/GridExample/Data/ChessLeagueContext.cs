using GridExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridExample.Data
{
    public class ChessLeagueContext : DbContext
    {
        public ChessLeagueContext(DbContextOptions<ChessLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    FirstCompetitorName = "Alex M. Swilley",
                    FirstCompetitorPhotoFileName = "face_icons-01m.png",
                    SecondCompetitorName = "Gretchen O. Fisher",
                    SecondCompetitorPhotoFileName = "face_icons-04m.png",
                    GamesQuantity = 6,
                    FinalScore = "4:2"
                },
                new Game
                {
                    GameId = 2,
                    FirstCompetitorName = "Robert D. Short",
                    FirstCompetitorPhotoFileName = "face_icons-05m.png",
                    SecondCompetitorName = "Janet M. Morrow",
                    SecondCompetitorPhotoFileName = "face_icons-02w.png",
                    GamesQuantity = 4,
                    FinalScore = "2:2"
                },
                new Game
                {
                    GameId = 3,
                    FirstCompetitorName = "Valerie H. Kent",
                    FirstCompetitorPhotoFileName = "face_icons-03w.png",
                    SecondCompetitorName = "Melvin D. Wagner",
                    SecondCompetitorPhotoFileName = "face_icons-09m.png",
                    GamesQuantity = 4,
                    FinalScore = "3:1"
                },
                new Game
                {
                    GameId = 4,
                    FirstCompetitorName = "Shirley B. Milligan",
                    FirstCompetitorPhotoFileName = "face_icons-06w.png",
                    SecondCompetitorName = "Michelle G. Garland",
                    SecondCompetitorPhotoFileName = "face_icons-07w.png",
                    GamesQuantity = 8,
                    FinalScore = "6:2"
                },
                new Game
                {
                    GameId = 5,
                    FirstCompetitorName = "Robert C. Lerner",
                    FirstCompetitorPhotoFileName = "face_icons-12m.png",
                    SecondCompetitorName = "Patricia D. Engel",
                    SecondCompetitorPhotoFileName = "face_icons-08w.png",
                    GamesQuantity = 5,
                    FinalScore = "3:2"
                },
                new Game
                {
                    GameId = 6,
                    FirstCompetitorName = "Cecile D. Jones",
                    FirstCompetitorPhotoFileName = "face_icons-10w.png",
                    SecondCompetitorName = "Billy C. Bowlin",
                    SecondCompetitorPhotoFileName = "face_icons-11m.png",
                    GamesQuantity = 6,
                    FinalScore = "5:1"
                });
        }
    }
}
