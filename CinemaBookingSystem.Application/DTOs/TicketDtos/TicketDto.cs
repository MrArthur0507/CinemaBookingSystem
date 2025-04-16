using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DTOs.TicketDtos
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public DateTime PurchaseTime { get; set; }
        public Guid ProjectionId { get; set; }
        public Guid SeatId { get; set; }
    }
}
