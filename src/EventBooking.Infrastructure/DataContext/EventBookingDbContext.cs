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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //For SQL provider
            modelBuilder.Entity<Event>()
                .HasIndex(x => x.Name)
                .IsUnique(true);
        }
    }
}
