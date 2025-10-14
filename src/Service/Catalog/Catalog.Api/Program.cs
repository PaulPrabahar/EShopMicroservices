using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions;
using Catalog.Api;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(otps =>
{
    otps.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// Register Mapster mappings
MapsterConfig.RegisterMappings();

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(options => { });

app.Run();
