using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.FranchiseService
{
    /// <summary>
    /// Franchise service class used for dependency injection.
    /// It frees up the Controllers and makes the program easier to manage and test.
    /// Implements FranchiseService interface.
    /// </summary>
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieCharactersDbContext _context;
        public FranchiseService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// A method to add a Franchise to the database.
        /// </summary>
        /// <param name="franchise">Franchise object to add</param>
        /// <returns></returns>
        public async Task<Franchise> AddEntityAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return franchise;
        }

        /// <summary>
        /// A method to remove a Franchise with a given Id from the database.
        /// </summary>
        /// <param name="id">Id to find Franchise</param>
        /// <returns></returns>
        public async Task DeleteEntityAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to check if a Franchise with given Id exists in the database.
        /// </summary>
        /// <param name="id">Id to find Franchise</param>
        /// <returns></returns>
        public bool EntityExists(int id)
        {
            return _context.Franchises.Any(fr => fr.FranchiseId == id);
        }

        /// <summary>
        /// A mehod to return a Franchise (and their movie list) with given Id.
        /// </summary>
        /// <param name="id">Id to find Franchise</param>
        /// <returns></returns>
        public async Task<Franchise> GetEntityByIdAsync(int id)
        {
            var franchise = await _context.Franchises.Include(fr => fr.Movies).Where(ch => ch.FranchiseId == id).FirstOrDefaultAsync();

            return franchise;
        }

        /// <summary>
        /// A method to find all Franchises in the database.
        /// </summary>
        /// <returns>A list of Franchise objects</returns>
        public async Task<IEnumerable<Franchise>> GetAllAsync()
        {
            var franchises = await _context.Franchises.Include(fr => fr.Movies).ToListAsync();

            return franchises;
        }

        /// <summary>
        /// A method to update a Franchise
        /// </summary>
        /// <param name="franchise">Franchise object that will replace the old Franchise</param>
        /// <returns></returns>
        public async Task UpdateEntityAsync(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to update Movie list of a Franchise with given Id.
        /// </summary>
        /// <param name="id">Id to find Franchise</param>
        /// <param name="movieIds">List of movie Ids to replace the old Movie Id list</param>
        /// <returns></returns>
        public async Task UpdateMovies(int id, List<int> movieIds)
        {
            var franchiseToUpdateMovies = await _context.Franchises
                .Include(ch => ch.Movies)
                .Where(fr => fr.FranchiseId == id)
                .FirstOrDefaultAsync();

            List<Movie> movies = franchiseToUpdateMovies.Movies.ToList();

            foreach (var movieId in movieIds)
            {
                Movie movie = await _context.Movies.FindAsync(movieId);
                if (!movies.Contains(movie))
                {
                    movies.Add(movie);
                }
            }

            franchiseToUpdateMovies.Movies = movies;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// A method to find all Character in a Franchise with given Id.
        /// </summary>
        /// <param name="id">Id to find Franchise</param>
        /// <returns>List of Character objects</returns>
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
