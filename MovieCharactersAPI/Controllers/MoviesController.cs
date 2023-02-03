using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models.Data;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Character;
using MovieCharactersAPI.Models.DTO.Movie;
using MovieCharactersAPI.Services.MovieService;

namespace MovieCharactersAPI.Controllers
{
    /// <summary>
    /// Controller class for Movies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Movies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _movieService.GetAllAsync());
        }

        /// <summary>
        /// Get a Character list of a Movie with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Characters/{id}")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetMovieCharacters(int id)
        {
            if (!_movieService.EntityExists(id))
            {
                return NotFound();
            }

            return _mapper.Map<List<CharacterReadDTO>>(await _movieService.GetAllCharacters(id));
        }

        /// <summary>
        /// Get a Movie with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            if (!_movieService.EntityExists(id))
            {
                return NotFound();
            }

            var movieDTO = _mapper.Map<MovieReadDTO>(await _movieService.GetEntityByIdAsync(id));

            return movieDTO;
        }

        /// <summary>
        /// Update a movie with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<MovieReadDTO>> PutMovie(int id, MovieEditDTO movieDTO)
        {
            if (id != movieDTO.MovieId)
            {
                return BadRequest();
            }
            if (!_movieService.EntityExists(id))
            {
                return NotFound();
            }

            Movie domainMovie = _mapper.Map<Movie>(movieDTO);
            await _movieService.UpdateEntityAsync(domainMovie);

            return _mapper.Map<MovieReadDTO>(await _movieService.GetEntityByIdAsync(id)); ;
        }

        /// <summary>
        /// Update Character list of a Movie with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterIds"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("Characters/{id}")]
        public async Task<ActionResult<MovieReadDTO>> PutMovieCharacters(int id, List<int> characterIds)
        {
            if (!_movieService.EntityExists(id))
            {
                return NotFound();
            }

            await _movieService.UpdateCharactersAsync(id, characterIds);

            return _mapper.Map<MovieReadDTO>(await _movieService.GetEntityByIdAsync(id));
        }

        /// <summary>
        /// Create a new Movie.
        /// </summary>
        /// <param name="movieDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<MovieReadDTO>> PostMovie(MovieCreateDTO movieDTO)
        {
            Movie domainMovie = _mapper.Map<Movie>(movieDTO);
            await _movieService.AddEntityAsync(domainMovie);

            return CreatedAtAction("GetMovie", new { id = domainMovie.MovieId }, _mapper.Map<MovieReadDTO>(domainMovie));
        }

        /// <summary>
        /// Delete an existing Movie with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieReadDTO>> DeleteMovie(int id)
        {
            if (!_movieService.EntityExists(id))
            {
                return NotFound();
            }
            await _movieService.DeleteEntityAsync(id);

            return Ok();
        }
    }
}
