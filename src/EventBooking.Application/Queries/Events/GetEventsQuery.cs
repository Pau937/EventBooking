using EventBooking.Application.Models;
using EventBooking.Application.Results;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public sealed record GetEventsQuery(string? Country, int Take, int Skip) : IRequest<Result<PagedList<EventViewModel>>>;
}
