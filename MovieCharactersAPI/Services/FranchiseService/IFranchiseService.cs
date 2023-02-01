using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.FranchiseService
{
    public interface IFranchiseService : IService<Franchise>
    {
        public Task UpdateMovies(int id, List<int> movieIds);
        public Task<IEnumerable<Character>> GetAllCharacters(int id);
    }
}
