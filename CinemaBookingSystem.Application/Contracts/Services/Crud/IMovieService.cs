using CinemaBookingSystem.Application.DTOs.MovieDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Services.Crud
{
    public interface IMovieService
    {
        Task<MovieDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<bool> CreateAsync(CreateMovieDto movieDto);
        Task<bool> UpdateAsync(UpdateMovieDto movieDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
