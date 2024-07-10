using System.ComponentModel.DataAnnotations;

namespace EventBooking.API.Dtos
{
    public record CreateEventDto
    {
        public CreateEventDto(string name, string country, string description, DateTime startDate, int numberOfSeats)
        {
            Name = name;
            Country = country;
            Description = description;
            StartDate = startDate;
            NumberOfSeats = numberOfSeats;
        }

        [Length(1, 50, ErrorMessage = $"The {nameof(Name)} length should be between 1 and 50 characters.")]
        public string Name { get; set; }

        [Length(1, 20, ErrorMessage = $"The {nameof(Country)} length should be between 1 and 20 characters.")]
        public string Country { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        [Range(1, 100, ErrorMessage = $"The {nameof(NumberOfSeats)} value should be between 1 and 100.")]
        public int NumberOfSeats { get; set; }
    }
}
