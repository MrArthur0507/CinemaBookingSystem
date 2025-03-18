using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql
{
    public static class CinemaLocationQueries
    {
        public const string Insert = @"INSERT INTO CinemaLocations (Id, City, CinemaAddress) VALUES (@Id, @City, @CinemaAddress);";

        public const string GetById = @"SELECT * FROM CinemaLocations WHERE Id = @Id;";

        public const string GetAll = @"SELECT * FROM CinemaLocations;";

        public const string Update = @"UPDATE CinemaLocations SET City = @City, CinemaAddress = @CinemaAddress WHERE Id = @Id;";

        public const string Delete = @"DELETE FROM CinemaLocations WHERE Id = @Id;";
    }
}
