using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using EventBooking.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.Repositories
{
    public class RegistrationRepository(EventBookingDbContext dbContext) : EFCoreRepository<Registration>(dbContext), IRegistrationRepository
    {
        public async Task<bool> IsRegistrationExists(string email, int eventId)
        {
            return await _dbContext.Registrations.AnyAsync(x => x.Email == email && x.EventId == eventId);
        }
    }
}
