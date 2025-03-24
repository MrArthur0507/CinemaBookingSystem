using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.MovieDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
                return NotFound(new { Message = "Movie not found" });

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _movieService.CreateAsync(movieDto);
            if (!result)
                return BadRequest(new { Message = "Unable to create movie" });

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateMovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _movieService.UpdateAsync(movieDto);
            if (!result)
                return NotFound(new { Message = "Movie not found or update failed" });

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _movieService.DeleteAsync(id);
            if (!result)
                return NotFound(new { Message = "Movie not found or deletion failed" });

            return NoContent();
        }
    }
}
