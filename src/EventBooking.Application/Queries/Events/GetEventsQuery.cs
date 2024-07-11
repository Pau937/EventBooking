using EventBooking.Application.Models;
using EventBooking.Application.Results;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public sealed record GetEventsQuery(string? Country, int Take = 20, int Skip = 0) : IRequest<Result<PagedList<EventViewModel>>>;
}
