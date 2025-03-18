using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.DbInitializationContracts
{
    public interface IDbInitializer
    {
        public void InitializeDatabase(string connectionString, string query);
    }
}
