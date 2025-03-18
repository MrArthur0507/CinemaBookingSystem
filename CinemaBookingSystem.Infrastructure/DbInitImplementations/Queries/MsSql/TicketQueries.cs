using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql
{
    public static class TicketQueries
    {
        public const string Insert = @"INSERT INTO Tickets (Id, ProjectionId, PurchaseTime, SeatId) VALUES (@Id, @ProjectionId, @PurchaseTime, @SeatId);";

        public const string GetById = @"SELECT * FROM Tickets WHERE Id = @Id;";

        public const string GetAllByProjectionId = @"SELECT * FROM Tickets WHERE ProjectionId = @ProjectionId;";

        public const string Delete = @"DELETE FROM Tickets WHERE Id = @Id;";

        public const string CheckSeatAvailability = @"SELECT COUNT(*) FROM Tickets WHERE ProjectionId = @ProjectionId AND SeatId = @SeatId;";
    }
}
