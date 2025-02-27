using CinemaBookingSystem.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Core.Entities
{
    public class CinemaLocation : BaseEntity
    {
        public string City { get; set; }
        public string CinemaAddress { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
