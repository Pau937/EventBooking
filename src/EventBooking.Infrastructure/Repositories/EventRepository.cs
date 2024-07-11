using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using EventBooking.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.Repositories
{
    public class EventRepository(EventBookingDbContext dbContext) : EFCoreRepository<Event>(dbContext), IEventRepository
    {
        public async Task<bool> IsNameExists(string name)
        {
            return await _dbContext.Events.AnyAsync(e => e.Name == name);
        }

        public override async Task<Event?> GetByIdAsync(int id)
        {
            return await _dbContext.Events.Include(x => x.Registrations).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
