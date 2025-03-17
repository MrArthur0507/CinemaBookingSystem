using CinemaBookingSystem.Application.DbInitializationContracts;
using CinemaBookingSystem.Infrastructure.DbInitImplementations;
using CinemaBookingSystem.Presentation.HostedServices;
using System.Runtime.CompilerServices;

namespace CinemaBookingSystem.Presentation.ExtensionMethods
{
    public static class ApplicationExtension
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IDbExistenceChecker, MSSqlExistenceChecker>();
            builder.Services.AddHostedService<DbCreationHostedService>();
        }

        public static void ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
