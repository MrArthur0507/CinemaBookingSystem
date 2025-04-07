using CinemaBookingSystem.Application.DTOs.CinemaLocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Services.Crud
{
    public interface ICinemaLocationService
    {
        Task<CinemaLocationDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CinemaLocationDto>> GetAllAsync();
        Task<bool> CreateAsync(CreateCinemaLocationDto cinemaLocationDto);
        Task<bool> UpdateAsync(UpdateCinemaLocationDto cinemaLocationDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
