using EventBooking.Application.Queries.Events.Responses;
using EventBooking.Application.Results;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public sealed record GetEventsQuery(string? Country, int Take = 20, int Skip = 0) : IRequest<Result<GetEventsQueryResponse>>;
}
