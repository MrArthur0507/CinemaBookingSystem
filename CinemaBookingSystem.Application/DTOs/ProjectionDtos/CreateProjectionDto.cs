using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DTOs.ProjectionDtos
{
    public class CreateProjectionDto
    {
        public DateTime ProjectionTime { get; set; }
        public decimal TicketPrice { get; set; }
        public Guid MovieId { get; set; }
        public Guid RoomId { get; set; }
    }
}
