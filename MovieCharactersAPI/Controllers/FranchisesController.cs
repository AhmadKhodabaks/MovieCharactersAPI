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
using MovieCharactersAPI.Models.DTO.Franchise;
using MovieCharactersAPI.Services.FranchiseService;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _franchiseService.GetFranchisesAsync());
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            var franchiseDTO = _mapper.Map<FranchiseReadDTO>(await _franchiseService.GetFranchiseByIdAsync(id));

            if (franchiseDTO == null)
            {
                return NotFound();
            }

            return franchiseDTO;
        }

        // PUT: api/Franchises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseEditDTO franchiseDTO)
        {
            if (id != franchiseDTO.FranchiseId)
            {
                return BadRequest();
            }
            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }
            Franchise domainFranchise = _mapper.Map<Franchise>(franchiseDTO);

            await _franchiseService.UpdateFranchiseAsync(domainFranchise);

            return NoContent();
        }

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FranchiseReadDTO>> PostFranchise(FranchiseCreateDTO franchiseDTO)
        {
            Franchise domainFranchise = _mapper.Map<Franchise>(franchiseDTO);

            await _franchiseService.AddFranchiseAsync(domainFranchise);

            return CreatedAtAction("GetFranchise", new { id = domainFranchise.FranchiseId }, _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_franchiseService.FranchiseExists(id))
            {
                return NotFound();
            }
            await _franchiseService.DeleteFranchiseAsync(id);

            return NoContent();
        }
    }
}
