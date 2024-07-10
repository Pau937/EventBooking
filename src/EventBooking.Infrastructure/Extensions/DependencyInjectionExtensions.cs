using EventBooking.Domain.DataAccess;
using EventBooking.Infrastructure.DataContext;
using EventBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventBooking.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
            collection.AddDbContext<EventBookingDbContext>(x => x.UseInMemoryDatabase("BookingEventsDatabase"));

            return collection;
        }
    }
}
