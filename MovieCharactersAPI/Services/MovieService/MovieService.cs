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
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies.Include(mv => mv.Characters).Where(mv => mv.MovieId == id).FirstOrDefaultAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.Include(mv => mv.Characters).ToListAsync();
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(mv => mv.MovieId == id);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
