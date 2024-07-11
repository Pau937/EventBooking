using EventBooking.Application.Results;
using MediatR;

namespace EventBooking.Application.Commands.Registrations
{
    public sealed record CreateRegistrationToEventCommand(string Email, int EventId) : IRequest<Result<string>>;
}
