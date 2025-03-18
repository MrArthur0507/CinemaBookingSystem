using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql
{
    public static class RoomQueries
    {
        public const string Insert = @"INSERT INTO Rooms (Id, CinemaLocationId, RoomName) VALUES (@Id, @CinemaLocationId, @RoomName);";

        public const string GetById = @"SELECT * FROM Rooms WHERE Id = @Id;";

        public const string GetAll = @"SELECT * FROM Rooms;";

        public const string Update = @"UPDATE Rooms SET RoomName = @RoomName WHERE Id = @Id;";

        public const string Delete = @"DELETE FROM Rooms WHERE Id = @Id;";
    }
}
