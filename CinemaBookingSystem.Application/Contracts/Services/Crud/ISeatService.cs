using CinemaBookingSystem.Application.DTOs.SeatDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Services.Crud
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatDto>> GetAllAsync();
        Task<SeatDto?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(CreateSeatDto dto);
        Task<bool> UpdateAsync(UpdateSeatDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
