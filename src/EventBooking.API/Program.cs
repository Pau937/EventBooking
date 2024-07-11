using Asp.Versioning;
using EventBooking.API.Middlewares;
using EventBooking.Application.Commands.Events;
using EventBooking.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1);
    option.ReportApiVersions = true;
}).AddApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddControllers();
builder.Services.AddInfrastructure();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(CreateEventCommand).Assembly);
});

var app = builder.Build();

app.UseMiddleware<ErrorsMiddleware>();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.Run();
