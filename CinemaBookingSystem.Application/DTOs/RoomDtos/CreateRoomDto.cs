using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DTOs.RoomDtos
{
    public class CreateRoomDto
    {
        public string RoomName { get; set; }
        public Guid CinemaLocationId { get; set; }
    }
}
