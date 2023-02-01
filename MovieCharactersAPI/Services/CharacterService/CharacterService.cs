using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieCharactersDbContext _context;

        public CharacterService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<Character> AddEntityAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public bool EntityExists(int id)
        {
            return _context.Characters.Any(ch => ch.CharacterId == id);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            _context.Characters.Remove(character);

            await _context.SaveChangesAsync();
        }

        public async Task<Character> GetEntityByIdAsync(int id)
        {
            var character = await _context.Characters
                .Include(ch => ch.Movies)
                .Where(ch => ch.CharacterId == id)
                .FirstOrDefaultAsync();

            return character;
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            var characters = await _context.Characters
                .Include(ch => ch.Movies)
                .ToListAsync();

            return characters;
        }

        public async Task UpdateEntityAsync(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovies(int id, List<int> movieIds)
        {
            var characterToUpdateMovies = await _context.Characters
                .Include(ch => ch.Movies)
                .Where(ch => ch.CharacterId == id)
                .FirstOrDefaultAsync();

            List<Movie> movies = new List<Movie>();

            foreach (var movieId in movieIds)
            {
                Movie movie = await _context.Movies.FindAsync(movieId);
                movies.Add(movie);
            }

            characterToUpdateMovies.Movies = movies;
            await _context.SaveChangesAsync();
        }

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
