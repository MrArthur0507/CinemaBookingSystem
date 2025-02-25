using CinemaBookingSystem.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class Room : BaseEntity
    {
        public Room() {
            Seats = new List<Seat>();
        }
        public string RoomName { get; set; }

        public ICollection<Seat> Seats { get; set; }  
    }
}
