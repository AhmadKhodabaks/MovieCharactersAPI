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
        public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }

        public async Task DeleteFranchiseAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

        }

        public bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(fr => fr.FranchiseId == id);
        }

        public async Task<Franchise> GetFranchiseByIdAsync(int id)
        {
            var franchise = await _context.Franchises.Include(fr => fr.Movies).Where(ch => ch.FranchiseId == id).FirstOrDefaultAsync();
            return franchise;
        }

        public async Task<IEnumerable<Franchise>> GetFranchisesAsync()
        {
            return await _context.Franchises.Include(fr => fr.Movies).ToListAsync();
        }

        public async Task UpdateFranchiseAsync(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
