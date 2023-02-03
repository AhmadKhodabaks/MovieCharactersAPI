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
using MovieCharactersAPI.Models.DTO.Franchise;
using MovieCharactersAPI.Models.DTO.Movie;
using MovieCharactersAPI.Services.FranchiseService;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Franchises.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _franchiseService.GetAllAsync());
        }

        /// <summary>
        /// Get a Character list of a Franchise with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Characters/{id}")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetFranchiseCharacters(int id)
        {
            if (!_franchiseService.EntityExists(id))
            {
                return NotFound();
            }

            return _mapper.Map<List<CharacterReadDTO>>(await _franchiseService.GetAllCharacters(id));
        }

        /// <summary>
        /// Get a Franchise with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            if (!_franchiseService.EntityExists(id))
            {
                return NotFound();
            }

            var franchiseDTO = _mapper.Map<FranchiseReadDTO>(await _franchiseService.GetEntityByIdAsync(id));

            return franchiseDTO;
        }

        /// <summary>
        /// Update a Franchise with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchiseDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> PutFranchise(int id, FranchiseEditDTO franchiseDTO)
        {
            if (id != franchiseDTO.FranchiseId)
            {
                return BadRequest();
            }
            if (!_franchiseService.EntityExists(id))
            {
                return NotFound();
            }

            Franchise domainFranchise = _mapper.Map<Franchise>(franchiseDTO);

            await _franchiseService.UpdateEntityAsync(domainFranchise);

            return _mapper.Map<FranchiseReadDTO>(await _franchiseService.GetEntityByIdAsync(id));
        }

        /// <summary>
        /// Update the Movie list of a Franchise with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("Movies/{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> PutFranchiseMovies(int id, List<int> movieIds)
        {
            if (!_franchiseService.EntityExists(id))
            {
                return NotFound();
            }
            await _franchiseService.UpdateMovies(id, movieIds);

            return _mapper.Map<FranchiseReadDTO>(await _franchiseService.GetEntityByIdAsync(id));
        }

        /// <summary>
        /// Create a new Franchise.
        /// </summary>
        /// <param name="franchiseDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FranchiseReadDTO>> PostFranchise(FranchiseCreateDTO franchiseDTO)
        {
            Franchise domainFranchise = _mapper.Map<Franchise>(franchiseDTO);

            await _franchiseService.AddEntityAsync(domainFranchise);

            return CreatedAtAction("GetFranchise", new { id = domainFranchise.FranchiseId }, _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        /// <summary>
        /// Delete an exsiting Franchise with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> DeleteFranchise(int id)
        {
            if (!_franchiseService.EntityExists(id))
            {
                return NotFound();
            }
            await _franchiseService.DeleteEntityAsync(id);

            return Ok();
        }
    }
}
