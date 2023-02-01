using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    public interface IService<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetEntityByIdAsync(int id);
        public Task<T> AddEntityAsync(T t);
        public Task UpdateEntityAsync(T t);
        public Task DeleteEntityAsync(int id);
        public bool EntityExists(int id);
    }
}
