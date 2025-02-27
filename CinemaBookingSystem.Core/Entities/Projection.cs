using CinemaBookingSystem.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class Projection : BaseEntity
    {
        public DateTime ProjectionTime { get; set; }
        public decimal TicketPrice { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
