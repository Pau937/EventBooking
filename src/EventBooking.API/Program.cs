using EventBooking.Application.Commands.Events;
using EventBooking.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructure();

builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(CreateEventCommand).Assembly);
});

var app = builder.Build();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
