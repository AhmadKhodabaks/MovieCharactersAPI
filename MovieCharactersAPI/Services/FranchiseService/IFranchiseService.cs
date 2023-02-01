using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.FranchiseService
{
    /// <summary>
    /// Implements IService interfice with Franchise type.
    /// Defines specific methods for Franchise Service.
    /// </summary>
    public interface IFranchiseService : IService<Franchise>
    {
        public Task UpdateMovies(int id, List<int> movieIds);
        public Task<IEnumerable<Character>> GetAllCharacters(int id);
    }
}
