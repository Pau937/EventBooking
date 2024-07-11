using EventBooking.API.AutoMapper;
using EventBooking.API.Extensions;
using EventBooking.API.Middlewares;
using EventBooking.Application.Extensions;
using EventBooking.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.WithSerilog();

builder.Services.WithRateLimiting();
builder.Services.AddAutoMapper(typeof(EventProfile));
builder.Services.WithApiVersioning();
builder.Services.AddControllers();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorsMiddleware>();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.Run();
