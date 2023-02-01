using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.MovieService
{
    public interface IMovieService : IService<Movie>
    {
        public Task UpdateCharactersAsync(int id, List<int> characterIds);
        public Task<IEnumerable<Character>> GetAllCharacters(int id);
    }
}
