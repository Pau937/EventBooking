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
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //For SQL provider
            modelBuilder.Entity<Event>()
                .HasIndex(x => x.Name)
                .IsUnique(true);

            modelBuilder.Entity<Registration>()
                .HasKey(s => new { s.EventId, s.Email });

            modelBuilder.Entity<Registration>()
                .Ignore(x => x.Id);

            modelBuilder.Entity<Registration>()
                .HasOne(s => s.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
