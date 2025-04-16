using CinemaBookingSystem.Application.Contracts.Mapping;
using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.TicketDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IMapperAdapter _mapper;

        public TicketService(ITicketRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> GetAllAsync()
        {
            var tickets = await _repository.GetAllAsync();
            return _mapper.MapList<Ticket, TicketDto>(tickets);
        }

        public async Task<TicketDto?> GetByIdAsync(Guid id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            return _mapper.Map<Ticket, TicketDto>(ticket);
        }

        public async Task<bool> CreateAsync(CreateTicketDto ticketDto)
        {
            var ticket = _mapper.Map<CreateTicketDto, Ticket>(ticketDto);
            ticket.PurchaseTime = DateTime.UtcNow;
            var result = await _repository.AddAsync(ticket);
            return result == 1;
        }

        public async Task<bool> UpdateAsync(UpdateTicketDto ticketDto)
        {
            var ticket = _mapper.Map<UpdateTicketDto, Ticket>(ticketDto);
            var existing = await _repository.GetByIdAsync(ticket.Id);
            if (existing == null) return false;

            ticket.PurchaseTime = existing.PurchaseTime; 
            var result = await _repository.UpdateAsync(ticket);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return result == 1;
        }
    }
}
