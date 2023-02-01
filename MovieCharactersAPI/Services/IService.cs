using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services
{
    /// <summary>
    /// Generic Interface for Services.
    /// Defines methods that are used in all Services.W
    /// </summary>
    /// <typeparam name="T">Used as any Domain type.</typeparam>
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
