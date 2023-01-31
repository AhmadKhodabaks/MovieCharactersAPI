using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;

namespace MovieCharactersAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieCharactersDbContext _context;

        public CharacterService(MovieCharactersDbContext context)
        {
            _context = context;
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public bool CharacterExists(int id)
        {
            return _context.Characters.Any(ch => ch.CharacterId == id);
        }

        public async Task DeleteCharacterAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            var character = await _context.Characters.Include(ch => ch.Movies).Where(ch => ch.CharacterId == id).FirstOrDefaultAsync();
            return character;
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return await _context.Characters
                .Include(ch => ch.Movies)
                .ToListAsync();
        }

        public async Task UpdateCharacterAsync(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
