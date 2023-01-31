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
using MovieCharactersAPI.Services.CharacterService;
using NuGet.Protocol;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters() //OK
        {
            return _mapper.Map<List<CharacterReadDTO>>(await _characterService.GetCharactersAsync());
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id) //OK
        {
            var characterDTO = _mapper.Map<CharacterReadDTO>(await _characterService.GetCharacterByIdAsync(id));

            if (characterDTO == null)
            {
                return NotFound();
            }

            return characterDTO;
        }

        // PUT: api/Characters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDTO characterDTO) //Ok
        {
            if (id != characterDTO.CharacterId)
            {
                return BadRequest();
            }
            if (!_characterService.CharacterExists(id))
            {
                return NotFound();
            }

            Character domainCharacter = _mapper.Map<Character>(characterDTO);

            await _characterService.UpdateCharacterAsync(domainCharacter);

            return NoContent();
        }


        // POST: api/Characters
        [HttpPost]
        public async Task<IActionResult> PostCharacter(CharacterCreateDTO characterDTO) //not ok
        {
            Character domainCharacter = _mapper.Map<Character>(characterDTO);

            domainCharacter = await _characterService.AddCharacterAsync(domainCharacter);

            return CreatedAtAction("GetCharacter",
                new { id = domainCharacter.CharacterId },
                _mapper.Map<CharacterCreateDTO>(domainCharacter));
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id) //OK
        {
            if (!_characterService.CharacterExists(id))
            {
                return NotFound();
            }

            await _characterService.DeleteCharacterAsync(id);
            return NoContent();
        }

    }
}
