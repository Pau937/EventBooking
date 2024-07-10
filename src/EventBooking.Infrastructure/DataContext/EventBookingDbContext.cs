using EventBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Infrastructure.DataContext
{
    public class EventBookingDbContext : DbContext
    {
        public EventBookingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
