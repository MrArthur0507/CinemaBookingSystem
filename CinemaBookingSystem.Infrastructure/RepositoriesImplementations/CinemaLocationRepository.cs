using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Repositories.Base;
using CinemaBookingSystem.Core.Entities;
using CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql;
using CinemaBookingSystem.Infrastructure.RepositoriesImplementations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.RepositoriesImplementations
{
    public class CinemaLocationRepository : BaseRepository<CinemaLocation>, ICinemaLocationRepository
    {
        public CinemaLocationRepository(IQueryExecutor<CinemaLocation> queryExecutor) : base (queryExecutor)
        {
            
        }
        public override async Task<IEnumerable<CinemaLocation>> GetAllAsync()
        {
            return await _queryExecutor.GetAllAsync(CinemaLocationQueries.GetAll);
        }

        public override async Task<CinemaLocation?> GetByIdAsync(Guid id)
        {
            return await _queryExecutor.GetByIdAsync(CinemaLocationQueries.GetById, id);
        }

        public override async Task<int> AddAsync(CinemaLocation entity)
        {
            return await _queryExecutor.ExecuteAsync(CinemaLocationQueries.Insert, entity);
        }

        public override async Task<int> UpdateAsync(CinemaLocation entity)
        {
            return await _queryExecutor.ExecuteAsync(CinemaLocationQueries.Update, entity);
        }

        public override async Task<int> DeleteAsync(Guid id)
        {
            return await _queryExecutor.ExecuteAsync(CinemaLocationQueries.Delete, id);
        }

    }
}
