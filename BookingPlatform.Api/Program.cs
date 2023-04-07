using BookingPlatform.Application;
using BookingPlatform.Core;
using BookingPlatform.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseInfrastructure();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();