using CinemaBookingSystem.Core.Base;
using CinemaBookingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class Seat : BaseEntity
    {
        public string RoomId { get; set; }
        public Room? Room { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public SeatType SeatType { get; set; }
    }
}
