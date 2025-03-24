using CinemaBookingSystem.Application.Contracts.Mapping;
using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DTOs.MovieDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapperAdapter _mapper;

        public MovieService(IMovieRepository movieRepository, IMapperAdapter mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto?> GetByIdAsync(Guid id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie is null ? null : _mapper.Map<Movie, MovieDto>(movie);
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.MapList<Movie, MovieDto>(movies);
        }

        public async Task<bool> CreateAsync(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<CreateMovieDto, Movie>(movieDto);
            var result = await _movieRepository.AddAsync(movie);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(UpdateMovieDto movieDto)
        {
            var movie = _mapper.Map<UpdateMovieDto, Movie>(movieDto);
            var result = await _movieRepository.UpdateAsync(movie);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _movieRepository.DeleteAsync(id);
            return result > 0;
        }
    }
}
