using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql
{
    public class ProjectionQueries
    {
        public const string Insert = @"INSERT INTO Projections (Id, MovieId, RoomId, ProjectionTime, TicketPrice) VALUES (@Id, @MovieId, @RoomId, @ProjectionTime, @TicketPrice);";

        public const string GetById = @"SELECT * FROM Projections WHERE Id = @Id;";

        public const string GetAll = @"SELECT * FROM Projections;";

        public const string Update = @"UPDATE Projections SET ProjectionTime = @ProjectionTime, TicketPrice = @TicketPrice WHERE Id = @Id;";

        public const string Delete = @"DELETE FROM Projections WHERE Id = @Id;";
    }
}
