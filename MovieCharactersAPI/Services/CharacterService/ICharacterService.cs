using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<IEnumerable<Character>> GetCharactersAsync();
        public Task<Character> GetCharacterByIdAsync(int id);
        public Task<Character> AddCharacterAsync(Character character);
        public Task UpdateCharacterAsync(Character character);
        public Task DeleteCharacterAsync(int id);
        public bool CharacterExists(int id);
    }
}
