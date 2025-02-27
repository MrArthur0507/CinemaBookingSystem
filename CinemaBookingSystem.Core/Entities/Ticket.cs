using CinemaBookingSystem.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public DateTime PurchaseTime { get; set; }

        public Guid ProjectionId { get; set; }
        public Projection Projection { get; set; }

        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
