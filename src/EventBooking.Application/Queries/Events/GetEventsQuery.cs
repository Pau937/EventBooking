using EventBooking.Application.Queries.Events.Responses;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public sealed record GetEventsQuery(string? SearchTerm, int Take = 20, int Skip = 0) : IRequest<GetEventsQueryResponse>;
}
