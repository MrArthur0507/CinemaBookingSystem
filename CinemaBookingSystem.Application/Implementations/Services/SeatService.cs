using CinemaBookingSystem.Application.Contracts.Mapping;
using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.SeatDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _repository;
        private readonly IMapperAdapter _mapper;

        public SeatService(ISeatRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SeatDto>> GetAllAsync()
        {
            var seats = await _repository.GetAllAsync();
            return _mapper.MapList<Seat, SeatDto>(seats);
        }

        public async Task<SeatDto?> GetByIdAsync(Guid id)
        {
            var seat = await _repository.GetByIdAsync(id);
            return _mapper.Map<Seat, SeatDto>(seat);
        }

        public async Task<bool> CreateAsync(CreateSeatDto dto)
        {
            var seat = _mapper.Map<CreateSeatDto, Seat>(dto);
            var result = await _repository.AddAsync(seat);
            return result == 1;
        }

        public async Task<bool> UpdateAsync(UpdateSeatDto dto)
        {
            var seat = _mapper.Map<UpdateSeatDto, Seat>(dto);
            var result = await _repository.UpdateAsync(seat);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return result == 1;
        }

    }
}
