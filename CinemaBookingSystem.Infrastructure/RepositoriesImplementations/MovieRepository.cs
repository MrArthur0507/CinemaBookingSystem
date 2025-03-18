using CinemaBookingSystem.Application.Contracts.Repositories;
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
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(string connectionString) : base(connectionString) { } 
        public async Task<Movie?> GetByIdAsync(Guid id)
        {
            return await GetByIdAsync(MovieQueries.GetById, id);
        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await GetAllAsync(MovieQueries.GetAll);
        }
        public async Task<int> AddAsync(Movie entity)
        {
            return await ExecuteAsync(MovieQueries.Insert, entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await ExecuteAsync(MovieQueries.Delete, new { Id = id });
        }
        public async Task<int> UpdateAsync(Movie entity)
        {
            return await ExecuteAsync(MovieQueries.Update, entity);
        }
    }
}
