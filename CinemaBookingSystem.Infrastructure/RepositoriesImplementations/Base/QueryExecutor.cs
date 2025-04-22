using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Repositories.Base;
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
    public class QueryExecutor<T> : IQueryExecutor<T> where T : class
    {
        private readonly IDbConnection _dbConnection;

        public QueryExecutor(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<T?> GetByIdAsync(string query, Guid id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query)
        {
            return await _dbConnection.QueryAsync<T>(query);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query, object parameters)
        {
            return await _dbConnection.QueryAsync<T>(query, parameters);
        }

        public async Task<int> ExecuteAsync(string query, object paramaters)
        {
            return await _dbConnection.ExecuteAsync(query, paramaters);   
        }

        public async Task<bool> ExecuteTransaction(Func<IDbConnection, Task<bool>> transactionFunction)
        {
            return await transactionFunction.Invoke(_dbConnection);
        }
    }
}
