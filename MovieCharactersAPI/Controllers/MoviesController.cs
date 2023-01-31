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
using MovieCharactersAPI.Models.DTO.Movie;
using MovieCharactersAPI.Services.MovieService;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _movieService.GetMoviesAsync());
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            var movieDTO = _mapper.Map<MovieReadDTO>(await _movieService.GetMovieByIdAsync(id));

            if (movieDTO == null)
            {
                return NotFound();
            }

            return movieDTO;
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO movieDTO)
        {
            if (id != movieDTO.MovieId)
            {
                return BadRequest();
            }
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            Movie domainMovie = _mapper.Map<Movie>(movieDTO);
            await _movieService.UpdateMovieAsync(domainMovie);

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieReadDTO>> PostMovie(MovieCreateDTO movieDTO)
        {
            Movie domainMovie = _mapper.Map<Movie>(movieDTO);
            await _movieService.AddMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie", new { id = domainMovie.MovieId }, _mapper.Map<MovieReadDTO>(domainMovie));
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }
    }
}
