using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.CharacterService
{
    /// <summary>
    /// Implements IService interfice with Character type.
    /// Defines specific methods for Character Service.
    /// </summary>
    public interface ICharacterService : IService<Character>
    {
        public Task UpdateMovies(int id, List<int> movieIds);
        public Task<IEnumerable<Movie>> GetAllMovies(int id);
    }
}
