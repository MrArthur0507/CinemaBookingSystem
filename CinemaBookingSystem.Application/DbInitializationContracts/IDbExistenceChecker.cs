using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DbInitializationContracts
{
    public interface IDbExistenceChecker
    {
        public bool CheckDatabaseExists(string connectionString, string databaseName);
    }
}
