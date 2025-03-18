using CinemaBookingSystem.Application.DbInitializationContracts;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations
{
    public class MsSqlDbInitializer : IDbInitializer
    {
        public void InitializeDatabase(string connectionString, string queryPath)
        {
            string query = File.ReadAllText(queryPath);
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                ExecuteScript(connection, query);
                connection.Close();
            }
        }

        private void ExecuteScript(SqlConnection connection, string script)
        {

            var sqlBatches = script.Split(new[] { "\nGO", "\ngo", "\rGO", "\rgo" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var batch in sqlBatches)
            {
                if (!string.IsNullOrWhiteSpace(batch))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = batch.Trim();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
