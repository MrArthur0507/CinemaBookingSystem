using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Repositories.Base;
using CinemaBookingSystem.Core.Entities;
using CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql;
using CinemaBookingSystem.Infrastructure.RepositoriesImplementations.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Infrastructure.RepositoriesImplementations
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IQueryExecutor<Movie> queryExecutor) : base(queryExecutor) { } 
        public override async Task<Movie?> GetByIdAsync(Guid id)
        {
            return await _queryExecutor.GetByIdAsync(MovieQueries.GetById, id);
        }
        public override async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _queryExecutor.GetAllAsync(MovieQueries.GetAll);
        }
        public override async Task<int> AddAsync(Movie entity)
        {
            return await _queryExecutor.ExecuteAsync(MovieQueries.Insert, entity);
        }

        public override async Task<int> DeleteAsync(Guid id)
        {
            return await _queryExecutor.ExecuteAsync(MovieQueries.Delete, new { Id = id });
        }
        public override async Task<int> UpdateAsync(Movie entity)
        {
            return await _queryExecutor.ExecuteAsync(MovieQueries.Update, entity);
        }
    }
}
