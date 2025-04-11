using CinemaBookingSystem.Application.DTOs.ProjectionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Services.Crud
{
    public interface IProjectionService
    {
        Task<IEnumerable<ProjectionDto>> GetAllAsync();
        Task<ProjectionDto?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(CreateProjectionDto projectionDto);
        Task<bool> UpdateAsync(UpdateProjectionDto projectionDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
