using EventBooking.Domain.Models;

namespace EventBooking.Domain.DataAccess
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        Task<bool> IsRegistrationExists(string email, int eventId);
    }
}
