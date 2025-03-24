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
    public class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        public SeatRepository(IQueryExecutor<Seat> queryExecutor) : base(queryExecutor) { }

        public async override Task<IEnumerable<Seat>> GetAllAsync()
        {
            return await _queryExecutor.GetAllAsync(SeatQueries.GetAll);
        }

        public override async Task<Seat?> GetByIdAsync(Guid id)
        {
            return await _queryExecutor.GetByIdAsync(SeatQueries.GetById, id);
        }

        public override async Task<int> AddAsync(Seat entity)
        {
            return await _queryExecutor.ExecuteAsync(SeatQueries.Insert, entity);
        }
        public override async Task<int> UpdateAsync(Seat entity)
        {
            return await _queryExecutor.ExecuteAsync(SeatQueries.Update, entity);
        }

        public override async Task<int> DeleteAsync(Guid id)
        {
            return await _queryExecutor.ExecuteAsync(SeatQueries.Delete, id);
        }

    }
}
