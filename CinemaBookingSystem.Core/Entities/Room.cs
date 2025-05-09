﻿using CinemaBookingSystem.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class Room : BaseEntity
    {

        public string RoomName { get; set; }

        public Guid CinemaLocationId { get; set; }
        public CinemaLocation CinemaLocation { get; set; }

        public ICollection<Seat> Seats { get; set; }
        public ICollection<Projection> Projections { get; set; }
    }
}
