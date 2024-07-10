using EventBooking.Application.Queries.Events.Responses;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventsQueryHandler(IRepository<Event> eventRepository) : IRequestHandler<GetEventsQuery, GetEventsQueryResponse>
    {
        public Task<GetEventsQueryResponse> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = eventRepository.GetAll();

            if (!string.IsNullOrEmpty(request.Country))
            {
                events = events.Where(x => x.Country.Contains(request.Country));
            }

            return Task.FromResult(new GetEventsQueryResponse(events.Skip(request.Skip).Take(request.Take)));
        }
    }
}
