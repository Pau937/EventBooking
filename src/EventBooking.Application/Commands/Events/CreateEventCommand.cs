using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public sealed record CreateEventCommand(string Name, string Description, string Country, DateTime StartDate, int NumberOfSeats) : IRequest<int>;
}
