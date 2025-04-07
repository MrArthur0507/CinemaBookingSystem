using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.SeatDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seats = await _seatService.GetAllAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var seat = await _seatService.GetByIdAsync(id);
            if (seat == null)
                return NotFound("Seat not found.");

            return Ok(seat);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSeatDto dto)
        {
            var result = await _seatService.CreateAsync(dto);
            if (!result)
                return BadRequest("Failed to create seat.");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSeatDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var result = await _seatService.UpdateAsync(dto);
            if (!result)
                return NotFound("Seat not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _seatService.DeleteAsync(id);
            if (!result)
                return NotFound("Seat not found.");

            return NoContent();
        }
    }
}
