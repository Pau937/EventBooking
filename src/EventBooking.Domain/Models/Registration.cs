using EventBooking.Domain.Interfaces;

namespace EventBooking.Domain.Models
{
    public sealed class Registration : Entity
    {
        public Registration(int eventId, string email)
        {
            EventId = eventId;
            Email = email;
        }

        public Event Event { get; private set; }
        public string Email { get; private set; }
        public int EventId { get; private set; }
    }
}
