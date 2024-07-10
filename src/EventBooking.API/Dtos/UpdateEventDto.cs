using System.ComponentModel.DataAnnotations;

namespace EventBooking.API.Dtos
{
    public record UpdateEventDto : CreateEventDto
    {
        public UpdateEventDto(int id, string name, string country, string description, DateTime startDate, int numberOfSeats) : base(name, country, description, startDate, numberOfSeats)
        {
            Id = id;
        }

        [Range(1, int.MaxValue, ErrorMessage = "The Id field is required.")]
        public int Id { get; set; }
    }
}
