using EventBooking.Application.Results;
using MediatR;

namespace EventBooking.Application.Commands.Subscriptions
{
    public sealed record CreateSubscriptionCommand(string Email, int EventId) : IRequest<Result<bool>>;
}
