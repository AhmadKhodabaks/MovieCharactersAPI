using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieCharactersAPI.Models.Domain;
using System.Collections.Generic;

namespace MovieCharactersAPI.Models.Data
{
    /// <summary>
    /// Database context class for creating Database sets and seeding data to the database.
    /// </summary>
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
            modelBuilder.Entity<Character>().HasData(DataSeed.GetCharacters());
            modelBuilder.Entity<Movie>().HasData(DataSeed.GetMovies());
            modelBuilder.Entity<Franchise>().HasData(DataSeed.GetFranchises());

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
                       new { CharacterId = 2, MovieId = 2 },
                       new { CharacterId = 2, MovieId = 3 },
                       new { CharacterId = 3, MovieId = 3 }
                   );
               });
        }

    }
}
