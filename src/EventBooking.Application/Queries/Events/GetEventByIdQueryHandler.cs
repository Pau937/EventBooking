using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event?>
    {
        public Task<Event?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var events = new List<Event>
            {
                new(0, "test", "test2", "test3", DateTime.Now, 10),
                new(1, "test", "test2", "test3", DateTime.Now, 11),
                new(2, "test", "test2", "test3", DateTime.Now, 12)
            };

            return Task.FromResult(events.FirstOrDefault(x => x.Id == request.Id));
        }
    }
}
