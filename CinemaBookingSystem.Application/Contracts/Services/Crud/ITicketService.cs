using CinemaBookingSystem.Application.DTOs.TicketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Services.Crud
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetAllAsync();
        Task<TicketDto?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(CreateTicketDto ticketDto);
        Task<bool> UpdateAsync(UpdateTicketDto ticketDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
