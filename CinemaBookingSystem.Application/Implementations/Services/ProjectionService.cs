using CinemaBookingSystem.Application.Contracts.Mapping;
using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.ProjectionDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Services
{
    public class ProjectionService : IProjectionService
    {
        private readonly IProjectionRepository _repository;
        private readonly IMapperAdapter _mapper;

        public ProjectionService(IProjectionRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectionDto>> GetAllAsync()
        {
            var projections = await _repository.GetAllAsync();
            return _mapper.MapList<Projection, ProjectionDto>(projections);
        }

        public async Task<ProjectionDto?> GetByIdAsync(Guid id)
        {
            var projection = await _repository.GetByIdAsync(id);
            return _mapper.Map<Projection, ProjectionDto>(projection);
        }

        public async Task<bool> CreateAsync(CreateProjectionDto projectionDto)
        {
            var entity = _mapper.Map<CreateProjectionDto, Projection>(projectionDto);
            var result = await _repository.AddAsync(entity);
            return result == 1;
        }

        public async Task<bool> UpdateAsync(UpdateProjectionDto projectionDto)
        {
            var entity = _mapper.Map<UpdateProjectionDto, Projection>(projectionDto);
            var result = await _repository.UpdateAsync(entity);
            return result == 1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return result == 1;
        }

    }
}
