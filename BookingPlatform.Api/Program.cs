using BookingPlatform.Application;
using BookingPlatform.Core;
using BookingPlatform.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddCore()
    .AddInfrastructure()
    .AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();