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
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //For SQL provider
            modelBuilder.Entity<Event>()
                .HasIndex(x => x.Name)
                .IsUnique(true);

            modelBuilder.Entity<Subscription>()
                .HasKey(s => new { s.EventId, s.Email });

            modelBuilder.Entity<Subscription>()
                .Ignore(x => x.Id);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Event)
                .WithMany(e => e.Subscriptions)
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
