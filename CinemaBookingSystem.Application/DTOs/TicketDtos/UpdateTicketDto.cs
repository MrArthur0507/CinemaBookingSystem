using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DTOs.TicketDtos
{
    public class UpdateTicketDto
    {
        public Guid Id { get; set; }
        public Guid ProjectionId { get; set; }
        public Guid SeatId { get; set; }
    }
}
