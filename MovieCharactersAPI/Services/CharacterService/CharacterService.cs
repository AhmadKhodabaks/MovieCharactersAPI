using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.CharacterService
{
    /// <summary>
    /// Character service class used for dependency injection.
    /// It frees up the Controllers and makes the program easier to manage and test.
    /// Implements CharacterService interface.
    /// </summary>
    public class CharacterService : ICharacterService
    {
        private readonly MovieCharactersDbContext _context;

        public CharacterService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// A method to add a Character to the database.
        /// </summary>
        /// <param name="character">Character object</param>
        /// <returns></returns>
        public async Task<Character> AddEntityAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        /// <summary>
        /// A method to check if a Character with given Id exists in the database.
        /// </summary>
        /// <param name="id">Id to find Character</param>
        /// <returns>Whether a Character is found</returns>
        public bool EntityExists(int id)
        {
            return _context.Characters.Any(ch => ch.CharacterId == id);
        }

        /// <summary>
        /// A method to remove a character with a given Id from the database.
        /// </summary>
        /// <param name="id"> Id to find a Character</param>
        /// <returns></returns>
        public async Task DeleteEntityAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            _context.Characters.Remove(character);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A mehod to return a Character (and their movie list) with given Id.
        /// </summary>
        /// <param name="id">Id to find a Character</param>
        /// <returns>Character object</returns>
        public async Task<Character> GetEntityByIdAsync(int id)
        {
            var character = await _context.Characters
                .Include(ch => ch.Movies)
                .Where(ch => ch.CharacterId == id)
                .FirstOrDefaultAsync();

            return character;
        }

        /// <summary>
        /// A method to find all Characters in the database.
        /// </summary>
        /// <returns>List of Character object</returns>
        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            var characters = await _context.Characters
                .Include(ch => ch.Movies)
                .ToListAsync();

            return characters;
        }

        /// <summary>
        /// A method to update a Character
        /// </summary>
        /// <param name="character">Character object that will replace the old Character</param>
        /// <returns></returns>
        public async Task UpdateEntityAsync(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to update Movie list of a Character with given Id.
        /// </summary>
        /// <param name="id">Id to find correct Character</param>
        /// <param name="movieIds">List of movie Ids to replace the old Movie Id list</param>
        /// <returns></returns>
        public async Task UpdateMovies(int id, List<int> movieIds)
        {
            var characterToUpdateMovies = await _context.Characters
                .Include(ch => ch.Movies)
                .Where(ch => ch.CharacterId == id)
                .FirstOrDefaultAsync();

            List<Movie> movies = characterToUpdateMovies.Movies.ToList();

            foreach (var movieId in movieIds)
            {
                Movie movie = await _context.Movies.FindAsync(movieId);
                if (!movies.Contains(movie))
                {
                    movies.Add(movie);
                }
            }

            characterToUpdateMovies.Movies = movies;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to find all movies of a Character with given Id.
        /// </summary>
        /// <param name="id">Id to find a Character</param>
        /// <returns>List of movies.</returns>
        public async Task<IEnumerable<Movie>> GetAllMovies(int id)
        {
            var characterMovies = _context.Characters
                .Where(ch => ch.CharacterId == id)
                .SelectMany(ch => ch.Movies)
                .Include(mv => mv.Characters)
                .ToList();

            return characterMovies;
        }
    }
}
