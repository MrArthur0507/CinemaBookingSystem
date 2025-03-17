using CinemaBookingSystem.Application.DbInitializationContracts;
using CinemaBookingSystem.Infrastructure.DbInitImplementations;
using CinemaBookingSystem.Presentation.ExtensionMethods;
using CinemaBookingSystem.Presentation.HostedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.RegisterServices();

var app = builder.Build();

app.ConfigurePipeline();


app.Run();
