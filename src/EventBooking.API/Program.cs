using EventBooking.API.Middlewares;
using EventBooking.Application.Commands.Events;
using EventBooking.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(CreateEventCommand).Assembly);
});

var app = builder.Build();

app.UseMiddleware<ErrorsMiddleware>();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
