using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.FranchiseService
{
    public interface IFranchiseService
    {
        public Task<IEnumerable<Franchise>> GetFranchisesAsync();
        public Task<Franchise> GetFranchiseByIdAsync(int id);
        public Task<Franchise> AddFranchiseAsync(Franchise franchise);
        public Task UpdateFranchiseAsync(Franchise franchise);
        public Task DeleteFranchiseAsync(int id);
        public bool FranchiseExists(int id);
    }
}
