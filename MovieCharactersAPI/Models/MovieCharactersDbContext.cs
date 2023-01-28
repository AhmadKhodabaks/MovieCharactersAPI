using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieCharactersAPI.Models.Domain;
using System.Collections.Generic;

namespace MovieCharactersAPI.Models
{
    public class MovieCharactersDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public MovieCharactersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(new Character { CharacterId = 1, FullName = "FullName1", Alias = "None", Gender = Gender.Male, PictureURL = "Not Given" });
            modelBuilder.Entity<Character>().HasData(new Character { CharacterId = 2, FullName = "FullName2", Alias = "None", Gender = Gender.Male, PictureURL = "Not Given" });
            modelBuilder.Entity<Character>().HasData(new Character { CharacterId = 3, FullName = "FullName3", Alias = "None", Gender = Gender.Male, PictureURL = "Not Given" });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 1,
                Title = "Title1",
                Genre = "Genre3",
                ReleaseYear = "2001",
                Director = "Director1",
                PictureURL = "",
                TrailerURl = "",
                FranchiseId = 1
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 2,
                Title = "Title2",
                Genre = "Genre2",
                ReleaseYear = "2002",
                Director = "Director2",
                PictureURL = "",
                TrailerURl = "",
                FranchiseId = 2
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 3,
                Title = "Title3",
                Genre = "Genre3",
                ReleaseYear = "2003",
                Director = "Director3",
                PictureURL = "",
                TrailerURl = "",
                FranchiseId = 3
            });

            modelBuilder.Entity<Franchise>().HasData(new Franchise { FranchiseId = 1, Name = "Franchise1", Description = "Description1" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { FranchiseId = 2, Name = "Franchise2", Description = "Description2" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { FranchiseId = 3, Name = "Franchise3", Description = "Description3" });

            modelBuilder.Entity<Character>()
           .HasMany(ch => ch.Movies)
           .WithMany(m => m.Characters)
           .UsingEntity<Dictionary<string, object>>(
               "CharacterMovie",
               r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
               l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
               je =>
               {
                   je.HasKey("CharacterId", "MovieId");
                   je.HasData(
                       new { CharacterId = 1, MovieId = 1 },
                       new { CharacterId = 1, MovieId = 2 },
                       new { CharacterId = 1, MovieId = 3 },
                       new { CharacterId = 2, MovieId = 1 },
                       new { CharacterId = 2, MovieId = 2 },
                       new { CharacterId = 3, MovieId = 3 }
                   );
               });
        }

    }
}
