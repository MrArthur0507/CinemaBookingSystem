using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql
{
    public static class TicketQueries
    {
        public const string GetAll = @"SELECT * FROM Tickets;";

        public const string Insert = @"INSERT INTO Tickets (Id, ProjectionId, PurchaseTime, SeatId) VALUES (@Id, @ProjectionId, @PurchaseTime, @SeatId);";

        public const string GetById = @"SELECT * FROM Tickets WHERE Id = @Id;";

        public const string GetAllByProjectionId = @"SELECT * FROM Tickets WHERE ProjectionId = @ProjectionId;";

        public const string Delete = @"DELETE FROM Tickets WHERE Id = @Id;";

        public const string Update = @"UPDATE Tickets SET ProjectionId = @ProjectionId, PurchaseTime = @PurchaseTime, SeatId = @SeatId WHERE Id = @Id;";
    }
}
