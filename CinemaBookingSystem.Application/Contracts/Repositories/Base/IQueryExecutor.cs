using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts.Repositories.Base
{
    public interface IQueryExecutor<T> where T : class
    {
        Task<T?> GetByIdAsync(string query, Guid id);
        Task<IEnumerable<T>> GetAllAsync(string query);

        Task<IEnumerable<T>> GetAllAsync(string query, object parameters);
        Task<int> ExecuteAsync(string query, object parameters);
    }
}
