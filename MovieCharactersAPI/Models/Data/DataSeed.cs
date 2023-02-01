using Microsoft.CodeAnalysis.CSharp.Syntax;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Models.Data
{
    /// <summary>
    /// A class for createing objects - Characters, Movies, Franchises that are seeded to the database.
    /// </summary>
    public class DataSeed
    {
        /// <summary>
        /// Characters.
        /// </summary>
        /// <returns></returns>
        public static List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>()
            {
                new Character { CharacterId = 1, FullName = "FullName1", Alias = "None", Gender = Gender.Male, PictureURL = "Not Given" },
                new Character { CharacterId = 2, FullName = "FullName2", Alias = "None", Gender = Gender.Male, PictureURL = "Not Given" },
                new Character { CharacterId = 3, FullName = "FullName3", Alias = "None", Gender = Gender.Male, PictureURL = "Not Given" }
            };
            return characters;
        }
        /// <summary>
        /// Movies.
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
            new Movie()
            {
                MovieId = 1,
                Title = "Title1",
                Genre = "Genre3",
                ReleaseYear = "2001",
                Director = "Director1",
                PictureURL = "",
                TrailerURl = "",
                FranchiseId = 1
            },
            new Movie
            {
                MovieId = 2,
                Title = "Title2",
                Genre = "Genre2",
                ReleaseYear = "2002",
                Director = "Director2",
                PictureURL = "",
                TrailerURl = "",
                FranchiseId = 2
            },
            new Movie
            {
                MovieId = 3,
                Title = "Title3",
                Genre = "Genre3",
                ReleaseYear = "2003",
                Director = "Director3",
                PictureURL = "",
                TrailerURl = "",
                FranchiseId = 3
            }
        };
            return movies;
        }

        /// <summary>
        /// Franchises.
        /// </summary>
        /// <returns></returns>
        public static List<Franchise> GetFranchises()
        {
            List<Franchise> franchises = new List<Franchise>()
            {
                new Franchise { FranchiseId = 1, Name = "Franchise1", Description = "Description1" },
                new Franchise { FranchiseId = 2, Name = "Franchise2", Description = "Description2" },
                new Franchise { FranchiseId = 3, Name = "Franchise3", Description = "Description3" }
            };
            return franchises;
        }

    }
}
