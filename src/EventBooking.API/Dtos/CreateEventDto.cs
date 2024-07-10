using System.ComponentModel.DataAnnotations;

namespace EventBooking.API.Dtos
{
    public class CreateEventDto
    {
        [Length(1, 50, ErrorMessage = "asd")]
        public required string Name { get; set; }

        [Length(1, 20, ErrorMessage = "asd")]
        public required string Country { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }

        [Range(1, 100)]
        public int NumberOfSeats { get; set; }
    }
}
