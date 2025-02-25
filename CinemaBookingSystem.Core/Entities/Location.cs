using CinemaBookingSystem.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class Location : BaseEntity
    {
        public Location() {
            Rooms = new List<Room>();
        }
        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
