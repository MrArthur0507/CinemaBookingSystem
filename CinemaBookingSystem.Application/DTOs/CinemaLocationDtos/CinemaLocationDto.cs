using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DTOs.CinemaLocationDtos
{
    public class CinemaLocationDto
    {
        public Guid Id { get; set; }
        public string City { get; set; } 
        public string CinemaAddress { get; set; } 
    }
}
