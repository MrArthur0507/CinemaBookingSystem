using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBookingSystem.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMovieRepository _movieRepository;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {


            Movie movie = new Movie { 
                ReleaseDate = DateTime.Now,
                Genre = "Sci-Fi",
                Title = "Interstellar",
                
            };
            int result = await _movieRepository.AddAsync(movie);

            await _movieRepository.GetAllAsync();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
