using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Application.Contracts
{
    public interface IGenericRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<bool> AddAsync(T entity);

        public Task<T> GetAsync(Guid id);

        public Task<bool> UpdateAsync(T entity);  

        public Task<bool> DeleteAsync(Guid id);
    }
}
