using EventBooking.Application.Results;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public sealed record UpdateEventCommand(int Id, string Name, string Description, string Country, DateTime StartDate, int NumberOfSeats) : IRequest<Result<bool>>;
}
