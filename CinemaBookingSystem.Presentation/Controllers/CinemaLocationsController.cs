using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.CinemaLocationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaLocationsController : ControllerBase
    {
        private readonly ICinemaLocationService _cinemaLocationService;

        public CinemaLocationsController(ICinemaLocationService cinemaLocationService)
        {
            _cinemaLocationService = cinemaLocationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _cinemaLocationService.GetAllAsync();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var location = await _cinemaLocationService.GetByIdAsync(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCinemaLocationDto dto)
        {
            var result = await _cinemaLocationService.CreateAsync(dto);
            if (!result)
                return BadRequest("Creation failed.");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCinemaLocationDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched ID.");

            var result = await _cinemaLocationService.UpdateAsync(dto);
            if (!result)
                return NotFound("Update failed.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _cinemaLocationService.DeleteAsync(id);
            if (!result)
                return NotFound("Delete failed.");

            return NoContent();
        }
    }
}
