using EventBooking.Application.Queries.Events.Responses;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventsQueryHandler(IRepository<Event> eventRepository) : IRequestHandler<GetEventsQuery, GetEventsQueryResponse>
    {
        public async Task<GetEventsQueryResponse> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = eventRepository.GetAll();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                events = events.Where(x => x.Name.Contains(request.SearchTerm)
                    || x.Description.Contains(request.SearchTerm)
                    || x.Country.Contains(request.SearchTerm));
            }

            return new GetEventsQueryResponse(await events.Skip(request.Skip).Take(request.Take).ToListAsync());
        }
    }
}
