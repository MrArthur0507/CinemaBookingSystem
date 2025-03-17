using CinemaBookingSystem.Application.DbInitializationContracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.DbInitImplementations
{
    public class MSSqlExistenceChecker : IDbExistenceChecker
    {
        public bool CheckDatabaseExists(string connectionString, string databaseName)
        {
            string sqlQuery;
            bool result = false;
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                sqlQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        conn.Open();
                        int databaseID = (int)cmd.ExecuteScalar();
                        conn.Close();
                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }
    }
}
