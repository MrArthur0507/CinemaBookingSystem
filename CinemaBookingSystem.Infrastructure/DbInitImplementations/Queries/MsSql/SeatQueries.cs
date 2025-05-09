﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql
{
    public static class SeatQueries
    {
        public const string GetAll = @"SELECT * FROM Seats";

        public const string Insert = @"INSERT INTO Seats (Id, RoomId, SeatType, SeatRow, SeatColumn) VALUES (@Id, @RoomId, @SeatType, @SeatRow, @SeatColumn);";

        public const string GetById = @"SELECT * FROM Seats WHERE Id = @Id;";

        public const string GetAllByRoomId = @"SELECT * FROM Seats WHERE RoomId = @RoomId;";

        public const string Update = @"UPDATE Seats SET SeatType = @SeatType, SeatRow = @SeatRow, SeatColumn = @SeatColumn WHERE Id = @Id;";

        public const string Delete = @"DELETE FROM Seats WHERE Id = @Id;";

        public const string GetAllForProjection = @"SELECT s.Id, s.SeatRow, s.SeatColumn, s.SeatType FROM Seats s JOIN Projections p ON s.RoomId = p.RoomId WHERE p.Id = @Id;";
    }
}
