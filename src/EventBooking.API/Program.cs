using EventBooking.Application.Commands.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(CreateEventCommand).Assembly);
});

var app = builder.Build();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
