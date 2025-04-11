using AutoMapper;
using CinemaBookingSystem.Application.DTOs.ProjectionDtos;
using CinemaBookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Implementations.Mapping.Profiles
{
    public class ProjectionMappingProfile : Profile
    {
        public ProjectionMappingProfile()
        {
            CreateMap<Projection, ProjectionDto>().ReverseMap();
            CreateMap<CreateProjectionDto, Projection>();
            CreateMap<UpdateProjectionDto, Projection>();
        }
    }
}
