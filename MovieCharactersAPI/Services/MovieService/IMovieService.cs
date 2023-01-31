using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.MovieService
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetMoviesAsync();
        public Task<Movie> GetMovieByIdAsync(int id);
        public Task<Movie> AddMovieAsync(Movie movie);
        public Task UpdateMovieAsync(Movie movie);
        public Task DeleteMovieAsync(int id);
        public bool MovieExists(int id);
    }
}
