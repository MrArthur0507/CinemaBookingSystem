using CinemaBookingSystem.Application.Contracts.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.RepositoriesImplementations.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IQueryExecutor<T> _queryExecutor;

        public BaseRepository(IQueryExecutor<T> queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public abstract Task<T?> GetByIdAsync(Guid id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<int> AddAsync(T entity);
        public abstract Task<int> UpdateAsync(T entity);
        public abstract Task<int> DeleteAsync(Guid id);
    }
}
