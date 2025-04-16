using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.ProjectionDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionsController : ControllerBase
    {
        private readonly IProjectionService _projectionService;

        public ProjectionsController(IProjectionService projectionService)
        {
            _projectionService = projectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projections = await _projectionService.GetAllAsync();
            return Ok(projections);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var projection = await _projectionService.GetByIdAsync(id);
            if (projection == null)
                return NotFound();

            return Ok(projection);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectionDto dto)
        {
            var success = await _projectionService.CreateAsync(dto);
            if (!success)
                return BadRequest("Failed to create projection.");

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProjectionDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var success = await _projectionService.UpdateAsync(dto);
            if (!success)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _projectionService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return Ok();
        }

    }
}
