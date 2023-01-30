using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Character;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MovieCharactersDbContext _context;
        private readonly IMapper _mapper;

        public CharactersController(MovieCharactersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters() //OK
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _context.Characters
                .Include(ch => ch.Movies)
                .ToListAsync());
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id) //OK
        {
            var characterDTO = _mapper.Map<CharacterReadDTO>(await _context.Characters
                .Include(ch => ch.Movies)
                .FirstOrDefaultAsync(ch => ch.CharacterId == id));

            if (characterDTO == null)
            {
                return NotFound();
            }

            return characterDTO;
        }

        // PUT: api/Characters/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterEditDTO>> PutCharacter(int id, CharacterEditDTO characterDTO) //NOT MOVIES
        {
            if (id != characterDTO.CharacterId)
            {
                return BadRequest();
            }

            Character domainCharacter = _mapper.Map<Character>(characterDTO);

            _context.Entry(domainCharacter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return characterDTO;
        }

        // POST: api/Characters
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO character) // NOT MOVIES
        {
            Character domainCharacter = _mapper.Map<Character>(character);
            _context.Characters.Add(domainCharacter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter",
                new { id = domainCharacter.CharacterId },
                _mapper.Map<CharacterReadDTO>(domainCharacter));
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> DeleteCharacter(int id) //OK
        {
            var characterDomain = await _context.Characters
               .Include(ch => ch.Movies)
               .FirstOrDefaultAsync(ch => ch.CharacterId == id);

            var characterDTO = _mapper.Map<CharacterReadDTO>(characterDomain);

            if (characterDTO == null)
            {
                return NotFound();
            }
            _context.Characters.Remove(characterDomain);
            await _context.SaveChangesAsync();

            return characterDTO;
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}