using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public sealed record CreateEventCommand(string Name, string Country, string Description, DateTime StartDate, int numberOfSeats) : IRequest<bool>;
}
