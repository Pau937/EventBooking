using EventBooking.Application.Queries.Events.Responses;
using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventsQueryHandler(IRepository<Event> eventRepository) : IRequestHandler<GetEventsQuery, Result<GetEventsQueryResponse>>
    {
        public Task<Result<GetEventsQueryResponse>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = eventRepository.GetAll();

            if (!string.IsNullOrEmpty(request.Country))
            {
                events = events.Where(x => x.Country.Contains(request.Country));
            }

            var result = new GetEventsQueryResponse(events.Skip(request.Skip).Take(request.Take));

            return Task.FromResult(new Result<GetEventsQueryResponse>(result));
        }
    }
}
