using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.CharacterService
{
    public interface ICharacterService : IService<Character>
    {
        public Task UpdateMovies(int id, List<int> movieIds);
        public Task<IEnumerable<Movie>> GetAllMovies(int id);
    }
}
