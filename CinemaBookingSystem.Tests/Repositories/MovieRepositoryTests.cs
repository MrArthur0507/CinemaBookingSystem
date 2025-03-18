using CinemaBookingSystem.Application.Contracts.Repositories.Base;
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
        private readonly Mock<IQueryExecutor<Movie>> _mockQueryExecutor;
        private readonly MovieRepository _movieRepository;

        public MovieRepositoryTests()
        {
            _mockQueryExecutor = new Mock<IQueryExecutor<Movie>>();
            _movieRepository = new MovieRepository(_mockQueryExecutor.Object);
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

            _mockQueryExecutor.Setup(db => db.GetByIdAsync(MovieQueries.GetById, It.IsAny<Guid>()))
                .ReturnsAsync(expectedMovie);

            //Act
            Movie actualMovie = await _movieRepository.GetByIdAsync(movieId);

            //Assert
            Assert.NotNull(actualMovie);
            Assert.Equal(expectedMovie, actualMovie);

        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenMovieDoesNotExist()
        {
            // Arrange
            var movieId = Guid.NewGuid();

            _mockQueryExecutor
                .Setup(db => db.GetByIdAsync(MovieQueries.GetById, movieId))
                .ReturnsAsync((Movie?)null);

            // Act
            var result = await _movieRepository.GetByIdAsync(movieId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllMovies()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie { Id = Guid.NewGuid(), Title = "The Matrix", ReleaseDate = DateTime.UtcNow, Genre = "Sci-Fi" },
                new Movie { Id = Guid.NewGuid(), Title = "The Godfather", ReleaseDate = DateTime.UtcNow, Genre = "Crime" }
            };

            _mockQueryExecutor
                .Setup(db => db.GetAllAsync(MovieQueries.GetAll))
                .ReturnsAsync(movies);

            // Act
            var result = await _movieRepository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, m => m.Title == "The Matrix");
            Assert.Contains(result, m => m.Title == "The Godfather");
        }

        [Fact]
        public async Task AddAsync_ReturnsAffectedRows_WhenMovieIsAdded()
        {
            // Arrange
            var newMovie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Interstellar",
                ReleaseDate = DateTime.UtcNow,
                Genre = "Sci-Fi"
            };

            _mockQueryExecutor
                .Setup(db => db.ExecuteAsync(MovieQueries.Insert, newMovie))
                .ReturnsAsync(1); 

            // Act
            var result = await _movieRepository.AddAsync(newMovie);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
