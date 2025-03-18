using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql
{
    public static class MovieQueries
    {
        public const string Insert = @"INSERT INTO Movies (Id, Title, ReleaseDate, Genre) VALUES (@Id, @Title, @ReleaseDate, @Genre);";

        public const string GetById = @"SELECT * FROM Movies WHERE Id = @Id;";

        public const string GetAll = @"SELECT * FROM Movies;";

        public const string Update = @"UPDATE Movies SET Title = @Title, ReleaseDate = @ReleaseDate, Genre = @Genre WHERE Id = @Id;";

        public const string Delete = @"DELETE FROM Movies WHERE Id = @Id;";
    }
}
