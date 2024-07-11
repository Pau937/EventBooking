using EventBooking.Application.Models;
using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventsQueryHandler(IRepository<Event> eventRepository) : IRequestHandler<GetEventsQuery, Result<PagedList<EventViewModel>>>
    {
        public async Task<Result<PagedList<EventViewModel>>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var query = eventRepository.GetAll();

            if (!string.IsNullOrEmpty(request.Country))
            {
                query = query.Where(x => x.Country.Contains(request.Country));
            }

            var pagedList = await PagedList<EventViewModel>.CreateAsync(query.Select(x => new EventViewModel(x.Name, x.Description, x.StartDate)), request.Skip, request.Take);

            return new Result<PagedList<EventViewModel>>(pagedList);
        }
    }
}
