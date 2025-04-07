using AutoMapper;
using CinemaBookingSystem.Application.DTOs.SeatDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Mapping.Profiles
{
    public class SeatMappingProifle : Profile
    {
        public SeatMappingProifle()
        {
            CreateMap<Seat, SeatDto>().ReverseMap();
            CreateMap<UpdateSeatDto, Seat>();
            CreateMap<CreateSeatDto, Seat>();
        }
    }
}
