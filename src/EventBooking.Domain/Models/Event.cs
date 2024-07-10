using EventBooking.Domain.Interfaces;

namespace EventBooking.Domain.Models
{
    public sealed class Event : Entity
    {
        public Event(int id, string name, string country, string description, DateTime startDay, int numberOfSeats) : base(id)
        {
            Name = name;
            Country = country;
            Description = description;
            StartDay = startDay;
            NumberOfSeats = numberOfSeats;
        }

        public string Name { get; private set; }
        public string Country { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDay { get; private set; }
        public int NumberOfSeats { get; private set; }
    }
}
