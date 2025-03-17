
using CinemaBookingSystem.Application.DbInitializationContracts;

namespace CinemaBookingSystem.Presentation.HostedServices
{
    public class DbCreationHostedService : IHostedService
    {
        private readonly IDbExistenceChecker _dbExistenceChecker;
        private readonly IConfiguration _configuration;
        public DbCreationHostedService(IDbExistenceChecker dbExistenceChecker, IConfiguration configuration)
        {
            _dbExistenceChecker = dbExistenceChecker;
            _configuration = configuration;

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            string connectionString = _configuration.GetConnectionString("MsSql");
            Console.WriteLine(_dbExistenceChecker.CheckDatabaseExists(connectionString, "CinemaManagement"));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
