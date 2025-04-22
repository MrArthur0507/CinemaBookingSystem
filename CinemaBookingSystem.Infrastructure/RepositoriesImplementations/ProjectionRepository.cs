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
    public class ProjectionRepository : BaseRepository<Projection>, IProjectionRepository
    {
        public ProjectionRepository(IQueryExecutor<Projection> queryExecutor) : base(queryExecutor) { }

        public async override Task<IEnumerable<Projection>> GetAllAsync()
        {
            return await _queryExecutor.GetAllAsync(ProjectionQueries.GetAll);
        }

        public override async Task<Projection?> GetByIdAsync(Guid id)
        {
            return await _queryExecutor.GetByIdAsync(ProjectionQueries.GetById, id);
        }

        public async override Task<int> AddAsync(Projection entity)
        {
            return await _queryExecutor.ExecuteAsync(ProjectionQueries.Insert, entity);
        }

        public async override Task<int> DeleteAsync(Guid id)
        {
            return await _queryExecutor.ExecuteAsync(ProjectionQueries.Delete, new {Id = id});
        }

        public override async Task<int> UpdateAsync(Projection entity)
        {
            return await _queryExecutor.ExecuteAsync(ProjectionQueries.Update, entity);
        }
    }
}
