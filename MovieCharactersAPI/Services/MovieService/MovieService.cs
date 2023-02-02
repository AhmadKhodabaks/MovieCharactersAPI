using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.MovieService
{
    /// <summary>
    /// Movie service class used for dependency injection.
    /// It frees up the Controllers and makes the program easier to manage and test.
    /// Implements CharacterService interface.
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly MovieCharactersDbContext _context;
        public MovieService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// A method to add a Movie to the database.
        /// </summary>
        /// <param name="movie">Movie object to be added.</param>
        /// <returns></returns>
        public async Task<Movie> AddEntityAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        /// <summary>
        /// A method to delete a Movie with a given Id.
        /// </summary>
        /// <param name="id">Id to find Movie</param>
        /// <returns></returns>
        public async Task DeleteEntityAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to find a Movie with given Id
        /// </summary>
        /// <param name="id">Id to find Movie</param>
        /// <returns></returns>
        public async Task<Movie> GetEntityByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(mv => mv.Characters)
                .Where(mv => mv.MovieId == id)
                .FirstOrDefaultAsync();

            return movie;
        }

        /// <summary>
        /// A method to find all Movies in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .Include(mv => mv.Characters)
                .ToListAsync();
        }

        /// <summary>
        /// A method to check if A movie with given Id exists in the database.
        /// </summary>
        /// <param name="id">Id to find movie</param>
        /// <returns>Wheter a Movie exists</returns>
        public bool EntityExists(int id)
        {
            return _context.Movies.Any(mv => mv.MovieId == id);
        }

        /// <summary>
        /// A method to update lists of Character in a Movie with given id.
        /// </summary>
        /// <param name="id">Id to find Movie.</param>
        /// <param name="characterIds">List of character ids to replace the old list of Character ids</param>
        /// <returns></returns>
        public async Task UpdateCharactersAsync(int id, List<int> characterIds)
        {
            var movieToUpdateCharacters = await _context.Movies
                .Include(mv => mv.Characters)
                .Where(mv => mv.MovieId == id)
                .FirstOrDefaultAsync();

            List<Character> characters = movieToUpdateCharacters.Characters.ToList();

            foreach (var characterId in characterIds)
            {
                Character character = await _context.Characters.FindAsync(characterId);
                if (!characters.Contains(character))
                {
                    characters.Add(character);
                }
            }
            movieToUpdateCharacters.Characters = characters;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to update a Movie.
        /// </summary>
        /// <param name="movie">Movie object that will replace the old Movie</param>
        /// <returns></returns>
        public async Task UpdateEntityAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to return Characters in Movie with given Id.
        /// </summary>
        /// <param name="id">Id to find Movie</param>
        /// <returns></returns>
        public async Task<IEnumerable<Character>> GetAllCharacters(int id)
        {
            var movieCharacters = await _context.Movies
                .Where(mv => mv.MovieId == id)
                .SelectMany(mv => mv.Characters)
                .Include(ch => ch.Movies)
                .ToListAsync();

            return movieCharacters;
        }
    }
}
