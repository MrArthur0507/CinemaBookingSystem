﻿using CinemaBookingSystem.Application.Contracts.Mapping;
using CinemaBookingSystem.Application.Contracts.Repositories;
using CinemaBookingSystem.Application.Contracts.Repositories.Base;
using CinemaBookingSystem.Application.Contracts.Services.Crud;
using CinemaBookingSystem.Application.DbInitializationContracts;
using CinemaBookingSystem.Application.Implementations.Mapping;
using CinemaBookingSystem.Application.Implementations.Services;
using CinemaBookingSystem.Infrastructure.DbInitImplementations;
using CinemaBookingSystem.Infrastructure.RepositoriesImplementations;
using CinemaBookingSystem.Infrastructure.RepositoriesImplementations.Base;
using CinemaBookingSystem.Presentation.HostedServices;
using Microsoft.Data.SqlClient;
using System.Data;
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
            builder.Services.AddSingleton<IDbInitializer, MsSqlDbInitializer>();
            var connectionString = builder.Configuration.GetConnectionString("MsSql");
            builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
            builder.Services.AddScoped(typeof(IQueryExecutor<>), typeof(QueryExecutor<>));
            builder.Services.AddHostedService<DbCreationHostedService>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IMapperAdapter, AutoMapperAdapter>();

            //Movies
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();
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
