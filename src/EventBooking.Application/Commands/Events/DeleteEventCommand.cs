using EventBooking.Application.Results;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public sealed record DeleteEventCommand(int Id) : IRequest<Result<bool>>;
}
