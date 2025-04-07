using CinemaBookingSystem.Application.Contracts.Mapping;
using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.RoomDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapperAdapter _mapper;

        public RoomService(IRoomRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await _repository.GetAllAsync();
            return _mapper.MapList<Room, RoomDto>(rooms);
        }

        public async Task<RoomDto?> GetByIdAsync(Guid id)
        {
            var room = await _repository.GetByIdAsync(id);
            return _mapper.Map<Room, RoomDto>(room);
        }

        public async Task<bool> CreateAsync(CreateRoomDto dto)
        {
            var room = _mapper.Map<CreateRoomDto, Room>(dto);
            var result = await _repository.AddAsync(room);
            return result == 1;
        }

        public async Task<bool> UpdateAsync(UpdateRoomDto dto)
        {
            var room = _mapper.Map<UpdateRoomDto, Room>(dto);
            var result = await _repository.UpdateAsync(room);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return result == 1;
        }
    }
}
