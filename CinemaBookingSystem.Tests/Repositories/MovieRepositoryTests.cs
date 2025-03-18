using CinemaBookingSystem.Core.Entities;
using CinemaBookingSystem.Infrastructure.DbInitImplementations.Queries.MsSql;
using CinemaBookingSystem.Infrastructure.RepositoriesImplementations;
using Dapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Tests.Repositories
{
    public class MovieRepositoryTests
    {
        private readonly Mock<IDbConnection> _mockDbConnection;
        private readonly MovieRepository _movieRepository;

        public MovieRepositoryTests()
        {
            _mockDbConnection = new Mock<IDbConnection>();
            _movieRepository = new MovieRepository(_mockDbConnection.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsMovie_WhenMovieExists()
        {
            //Arrange
            Guid movieId = Guid.NewGuid();
            Movie expectedMovie = new Movie { 
                Id = movieId,
                Title = "Interstellar",
                ReleaseDate = DateTime.UtcNow,
                Genre = "Sci-Fi"
            };

            _mockDbConnection.Setup(db => db.QueryFirstOrDefaultAsync<Movie>(MovieQueries.GetById, It.IsAny<object>(), null, null, null))
                .ReturnsAsync(expectedMovie);

            //Act
            Movie actualMovie = await _movieRepository.GetByIdAsync(movieId);

            //Assert
            Assert.NotNull(actualMovie);
            Assert.Equal(expectedMovie, actualMovie);

        }
    }
}
