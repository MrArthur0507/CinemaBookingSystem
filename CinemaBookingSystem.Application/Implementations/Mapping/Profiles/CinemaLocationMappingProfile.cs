using AutoMapper;
using CinemaBookingSystem.Application.DTOs.CinemaLocationDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Mapping.Profiles
{
    public class CinemaLocationMappingProfile : Profile
    {
        public CinemaLocationMappingProfile()
        {
            CreateMap<CinemaLocation, CinemaLocationDto>().ReverseMap();
            CreateMap<CreateCinemaLocationDto, CinemaLocation>();
            CreateMap<UpdateCinemaLocationDto, CinemaLocation>();
        }
    }
}
