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
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(IQueryExecutor<Ticket> queryExecutor) : base(queryExecutor) { }

        public override async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _queryExecutor.GetAllAsync(TicketQueries.GetAll);
        }

        public override async Task<Ticket?> GetByIdAsync(Guid id)
        {
            return await _queryExecutor.GetByIdAsync(TicketQueries.GetById, id);
        }

        public override async Task<int> AddAsync(Ticket entity)
        {
            return await _queryExecutor.ExecuteAsync(TicketQueries.Insert, entity);
        }

        public override async Task<int> DeleteAsync(Guid id)
        {
            return await _queryExecutor.ExecuteAsync(TicketQueries.Delete, id);
        }

        public override async Task<int> UpdateAsync(Ticket entity)
        {
            return await _queryExecutor.ExecuteAsync(TicketQueries.Update, entity);
        }
    }
}
