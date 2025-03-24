using AutoMapper;
using CinemaBookingSystem.Application.DTOs.MovieDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Mapping.Profiles
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
        }
    }
}
