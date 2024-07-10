using EventBooking.Domain.Interfaces;

namespace EventBooking.Domain.Models
{
    public sealed class Event : Entity
    {
        private const int MAX_NAME_LENGTH = 50;
        private const int MAX_COUNTRY_LENGTH = 20;
        private const int MAX_NUMBER_OF_SEATS = 100;

        public Event(string name, string description, string country, DateTime startDate, int numberOfSeats)
        {
            Update(name, description, country, startDate, numberOfSeats);
        }

        public void Update(string name, string description, string country, DateTime startDate, int numberOfSeats)
        {
            if (name.Length > MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"The {nameof(Name)} max length is {MAX_NAME_LENGTH}.");
            }

            if (country.Length > MAX_COUNTRY_LENGTH)
            {
                throw new ArgumentException($"The {nameof(Country)} max length is {MAX_COUNTRY_LENGTH}.");
            }

            if (numberOfSeats > MAX_NUMBER_OF_SEATS)
            {
                throw new ArgumentException($"The {nameof(NumberOfSeats)} max is {MAX_NUMBER_OF_SEATS}.");
            }

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
