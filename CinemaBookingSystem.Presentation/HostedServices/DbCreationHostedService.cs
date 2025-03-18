
using CinemaBookingSystem.Application.DbInitializationContracts;

namespace CinemaBookingSystem.Presentation.HostedServices
{
    public class DbCreationHostedService : IHostedService
    {
        private readonly IDbExistenceChecker _dbExistenceChecker;
        private readonly IConfiguration _configuration;
        private readonly IDbInitializer _dbInitializer;
        public DbCreationHostedService(IDbExistenceChecker dbExistenceChecker, IConfiguration configuration, IDbInitializer dbInitializer)
        {
            _dbExistenceChecker = dbExistenceChecker;
            _configuration = configuration;
            _dbInitializer = dbInitializer;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            string connectionString = _configuration.GetConnectionString("MsSql");
            if (!_dbExistenceChecker.CheckDatabaseExists(connectionString, "CinemaManagement"))
            {
                _dbInitializer.InitializeDatabase(connectionString, _configuration["SqlScripts:CreateMSSqlDatabase"]);
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
