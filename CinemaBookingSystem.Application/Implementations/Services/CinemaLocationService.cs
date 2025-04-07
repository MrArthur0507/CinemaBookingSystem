using CinemaBookingSystem.Application.Contracts.Mapping;
using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.CinemaLocationDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Services
{
    public class CinemaLocationService : ICinemaLocationService
    {
        private readonly ICinemaLocationRepository _repository;
        private readonly IMapperAdapter _mapperAdapter;

        public CinemaLocationService(ICinemaLocationRepository repository, IMapperAdapter mapperAdapter)
        {
            _repository = repository;
            _mapperAdapter = mapperAdapter;
        }
        public async Task<CinemaLocationDto?> GetByIdAsync(Guid id)
        {
            var cinemaLocation = await _repository.GetByIdAsync(id);
            return _mapperAdapter.Map<CinemaLocation, CinemaLocationDto>(cinemaLocation);
        }

        public async Task<IEnumerable<CinemaLocationDto>> GetAllAsync()
        {
            var cinemaLocations = await _repository.GetAllAsync();
            return _mapperAdapter.MapList<CinemaLocation, CinemaLocationDto>(cinemaLocations);
        }

        public async Task<bool> CreateAsync(CreateCinemaLocationDto cinemaLocationDto)
        {
            var cinemaLocation = _mapperAdapter.Map<CreateCinemaLocationDto, CinemaLocation>(cinemaLocationDto);
            int result = await _repository.AddAsync(cinemaLocation);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            int result = await _repository.DeleteAsync(id);
            return result == 1;
        }

        public async Task<bool> UpdateAsync(UpdateCinemaLocationDto cinemaLocationDto)
        {
            var cinemaLocation = _mapperAdapter.Map<UpdateCinemaLocationDto, CinemaLocation>(cinemaLocationDto);
            int result = await _repository.UpdateAsync(cinemaLocation);
            return result == 1;
        }
    }
}
