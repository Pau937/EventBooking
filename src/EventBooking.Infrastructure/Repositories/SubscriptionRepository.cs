using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using EventBooking.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.Repositories
{
    public class SubscriptionRepository(EventBookingDbContext dbContext) : EFCoreRepository<Subscription>(dbContext), ISubscriptionRepository
    {
        public async Task<bool> IsSubscriptionExists(string email, int eventId)
        {
            return await dbContext.Subscriptions.AnyAsync(x => x.Email == email && x.EventId == eventId);
        }
    }
}
