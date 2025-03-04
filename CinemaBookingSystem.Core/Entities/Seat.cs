﻿using CinemaBookingSystem.Core.Base;
using CinemaBookingSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class Seat : BaseEntity
    {
        public string SeatType { get; set; }
        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }

        // Foreign Key
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        // Navigation Property
        public ICollection<Ticket> Tickets { get; set; }
    }
}
