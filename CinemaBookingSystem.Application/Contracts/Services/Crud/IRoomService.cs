using CinemaBookingSystem.Application.DTOs.RoomDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Services.Crud
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(CreateRoomDto dto);
        Task<bool> UpdateAsync(UpdateRoomDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
