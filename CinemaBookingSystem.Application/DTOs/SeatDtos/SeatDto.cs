using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DTOs.SeatDtos
{
    public class SeatDto
    {
        public Guid Id { get; set; }
        public string SeatType { get; set; }
        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }
        public Guid RoomId { get; set; }
    }
}
