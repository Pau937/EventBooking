using System.ComponentModel.DataAnnotations;

namespace EventBooking.API.Dtos
{
    public record CreateRegistrationDto
    {
        public CreateRegistrationDto(string email, int eventId)
        {
            Email = email;
            EventId = eventId;
        }

        [EmailAddress(ErrorMessage = "The provided email is invalid.")]
        public string Email { get; private set; }
        public int EventId { get; private set; }
    }
}
