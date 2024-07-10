using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public sealed record DeleteEventCommand(int Id) : IRequest<bool>;
}
