using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public sealed record GetEventByIdQuery(int Id) : IRequest<Event?>;
}
