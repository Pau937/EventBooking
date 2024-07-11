using EventBooking.Application.Commands.Events;
using Microsoft.Extensions.DependencyInjection;

namespace EventBooking.Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(typeof(CreateEventCommand).Assembly);
            });

            return services;
        }
    }
}
