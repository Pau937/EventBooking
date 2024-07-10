using EventBooking.Domain.Interfaces;

namespace EventBooking.Domain.Models
{
    public sealed class Event : Entity
    {
        public Event(string name, string description, string country, DateTime startDate, int numberOfSeats)
        {
            Name = name;
            Country = country;
            Description = description;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
        }

        public void Update(string name, string description, string country, DateTime startDate, int numberOfSeats)
        {
            Name = name;
            Description = description;
            Country = country;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
        }

        public string Name { get; private set; }
        public string Country { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public int NumberOfSeats { get; private set; }
    }
}
