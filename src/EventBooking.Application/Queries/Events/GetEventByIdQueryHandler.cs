using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventByIdQueryHandler(IRepository<Event> eventRepository) : IRequestHandler<GetEventByIdQuery, Event?>
    {
        public async Task<Event?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await eventRepository.GetByIdAsync(request.Id);
        }
    }
}
