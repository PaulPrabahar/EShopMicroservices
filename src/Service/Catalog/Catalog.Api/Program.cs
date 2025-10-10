using BuildingBlocks.Behaviours;
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

// Register Mapster mappings
MapsterConfig.RegisterMappings();

var app = builder.Build();

app.MapCarter();

app.Run();
