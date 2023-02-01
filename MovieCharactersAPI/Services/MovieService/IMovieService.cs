using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.MovieService
{
    /// <summary>
    /// Implements IService interfice with Movie type.
    /// Defines specific methods for Movie Service.
    /// </summary>
    public interface IMovieService : IService<Movie>
    {
        public Task UpdateCharactersAsync(int id, List<int> characterIds);
        public Task<IEnumerable<Character>> GetAllCharacters(int id);
    }
}
