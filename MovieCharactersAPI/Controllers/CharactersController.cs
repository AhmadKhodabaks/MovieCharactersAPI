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
using MovieCharactersAPI.Models.DTO.Movie;
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
            return _mapper.Map<List<CharacterReadDTO>>(await _characterService.GetAllAsync());
        }

        [HttpGet("Movies/{id}")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetAllMovies(int id) //OK
        {
            if (!_characterService.EntityExists(id))
            {
                return NotFound();
            }

            return _mapper.Map<List<MovieReadDTO>>(await _characterService.GetAllMovies(id));
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id) //OK
        {
            if (!_characterService.EntityExists(id))
            {
                return NotFound();
            }

            var characterDTO = _mapper.Map<CharacterReadDTO>(await _characterService.GetEntityByIdAsync(id));

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
            if (!_characterService.EntityExists(id))
            {
                return NotFound();
            }

            Character domainCharacter = _mapper.Map<Character>(characterDTO);
            await _characterService.UpdateEntityAsync(domainCharacter);

            return NoContent();
        }
        // PUT: api/Characters/Movies/5
        [HttpPut("Movies/{id}")]
        public async Task<IActionResult> PutMoviesInCharacter(int id, List<int> movieIds) //Ok
        {
            if (!_characterService.EntityExists(id))
            {
                return NotFound();
            }

            await _characterService.UpdateMovies(id, movieIds);

            return NoContent();
        }


        // POST: api/Characters
        [HttpPost]
        public async Task<IActionResult> PostCharacter(CharacterCreateDTO characterDTO) //not ok
        {
            Character domainCharacter = _mapper.Map<Character>(characterDTO);

            domainCharacter = await _characterService.AddEntityAsync(domainCharacter);

            return CreatedAtAction("GetCharacter",
                new { id = domainCharacter.CharacterId },
                _mapper.Map<CharacterCreateDTO>(domainCharacter));
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id) //OK
        {
            if (!_characterService.EntityExists(id))
            {
                return NotFound();
            }

            await _characterService.DeleteEntityAsync(id);
            return NoContent();
        }
    }
}
