using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.FranchiseService
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieCharactersDbContext _context;
        public FranchiseService(MovieCharactersDbContext context)
        {
            _context = context;
        }
        public async Task<Franchise> AddEntityAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return franchise;
        }

        public async Task DeleteEntityAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public bool EntityExists(int id)
        {
            return _context.Franchises.Any(fr => fr.FranchiseId == id);
        }

        public async Task<Franchise> GetEntityByIdAsync(int id)
        {
            var franchise = await _context.Franchises.Include(fr => fr.Movies).Where(ch => ch.FranchiseId == id).FirstOrDefaultAsync();

            return franchise;
        }

        public async Task<IEnumerable<Franchise>> GetAllAsync()
        {
            var franchises = await _context.Franchises.Include(fr => fr.Movies).ToListAsync();

            return franchises;
        }

        public async Task UpdateEntityAsync(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovies(int id, List<int> movieIds)
        {
            var franchiseToUpdateMovies = await _context.Franchises
                .Include(ch => ch.Movies)
                .Where(fr => fr.FranchiseId == id)
                .FirstOrDefaultAsync();

            List<Movie> movies = new List<Movie>();

            foreach (var movieId in movieIds)
            {
                Movie movie = await _context.Movies.FindAsync(movieId);
                movies.Add(movie);
            }

            franchiseToUpdateMovies.Movies = movies;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllCharacters(int id)
        {
            var charactersInFranchise = await _context.Franchises
                .Where(fr => fr.FranchiseId == id)
                .SelectMany(fr => fr.Movies)
                .SelectMany(mv => mv.Characters)
                .Include(ch => ch.Movies)
                .ToListAsync();

            return charactersInFranchise;
        }
    }
}
