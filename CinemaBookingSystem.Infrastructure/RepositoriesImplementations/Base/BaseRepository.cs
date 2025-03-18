using CinemaBookingSystem.Application.Contracts.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.RepositoriesImplementations.Base
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;

        public BaseRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public async Task<T?> GetByIdAsync(string query, Guid id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query)
        {
            return await _dbConnection.QueryAsync<T>(query);
        }

        public async Task<int> ExecuteAsync(string query, object paramaters)
        {
            return await _dbConnection.ExecuteAsync(query, paramaters);
        }
    }
}
