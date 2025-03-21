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
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(IQueryExecutor<Room> queryExecutor) : base(queryExecutor)
        {
            
        }
        public override async Task<Room?> GetByIdAsync(Guid id)
        {
            return await _queryExecutor.GetByIdAsync(RoomQueries.GetById, id);
        }

        public override async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _queryExecutor.GetAllAsync(RoomQueries.GetAll);
        }

        public override async Task<int> AddAsync(Room entity)
        {
            return await _queryExecutor.ExecuteAsync(RoomQueries.Insert, entity);
        }

        public override async Task<int> UpdateAsync(Room entity)
        {
            return await _queryExecutor.ExecuteAsync(RoomQueries.Update, entity);
        }

        public override async Task<int> DeleteAsync(Guid id)
        {
            return await _queryExecutor.ExecuteAsync(RoomQueries.Delete, id);
        }
    }
}

