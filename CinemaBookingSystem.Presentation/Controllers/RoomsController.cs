using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.RoomDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomDto dto)
        {
            var result = await _roomService.CreateAsync(dto);
            if (!result)
                return BadRequest("Failed to create room.");

            return Ok("Room created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateRoomDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var result = await _roomService.UpdateAsync(dto);
            if (!result)
                return NotFound("Room not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _roomService.DeleteAsync(id);
            if (!result)
                return NotFound("Room not found.");

            return NoContent();
        }
    }
}
