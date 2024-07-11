using EventBooking.Domain.Models;

namespace EventBooking.Domain.DataAccess
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Task<bool> IsSubscriptionExists(string email, int eventId);
    }
}
