using EventBooking.Application.Queries.Events.Responses;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, GetEventsQueryResponse>
    {
        public Task<GetEventsQueryResponse> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Event> events = new List<Event>
            {
                new(0, "test", "test2", "test3", DateTime.Now, 10),
                new(1, "test", "test2", "test3", DateTime.Now, 11),
                new(2, "test", "test2", "test3", DateTime.Now, 12)
            };

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                events = events.Where(x => x.Name.Contains(request.SearchTerm)
                    || x.Description.Contains(request.SearchTerm)
                    || x.Country.Contains(request.SearchTerm));
            }

            return Task.FromResult(new GetEventsQueryResponse(events.Skip(request.Skip).Take(request.Take)));
        }
    }
}
