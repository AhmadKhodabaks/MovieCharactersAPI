using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly MovieCharactersDbContext _context;
        public MovieService(MovieCharactersDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> AddEntityAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetEntityByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(mv => mv.Characters)
                .Where(mv => mv.MovieId == id)
                .FirstOrDefaultAsync();

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .Include(mv => mv.Characters)
                .ToListAsync();
        }

        public bool EntityExists(int id)
        {
            return _context.Movies.Any(mv => mv.MovieId == id);
        }

        public async Task UpdateCharactersAsync(int id, List<int> characterIds)
        {
            var movieToUpdateCharacters = await _context.Movies
                .Include(mv => mv.Characters)
                .Where(mv => mv.MovieId == id)
                .FirstOrDefaultAsync();

            List<Character> characters = new List<Character>();
            foreach (var characterId in characterIds)
            {
                Character character = await _context.Characters.FindAsync(characterId);
                characters.Add(character);
            }
            movieToUpdateCharacters.Characters = characters;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

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
