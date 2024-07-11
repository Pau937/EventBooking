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
            ValidateInput(name, country, numberOfSeats);

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
        public IList<Registration> Registrations { get; } = new List<Registration>();

        public void Update(string name, string description, string country, DateTime startDate, int numberOfSeats)
        {
            ValidateInput(name, country, numberOfSeats);

            Name = name;
            Description = description;
            Country = country;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
        }

        private static void ValidateInput(string name, string country, int numberOfSeats)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"The {nameof(Name)} length has to between 1 and {MAX_NAME_LENGTH}.");
            }

            if (string.IsNullOrWhiteSpace(country) || string.IsNullOrEmpty(country) || country.Length > MAX_COUNTRY_LENGTH)
            {
                throw new ArgumentException($"The {nameof(Country)} length has to between 1 and {MAX_COUNTRY_LENGTH}.");
            }

            if (numberOfSeats > MAX_NUMBER_OF_SEATS || numberOfSeats < 1)
            {
                throw new ArgumentException($"The {nameof(NumberOfSeats)} has to be between 1 and {MAX_NUMBER_OF_SEATS}.");
            }
        }
    }
}
