using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class CreateEventCommandHandler(IRepository<Event> eventsRepository) : IRequestHandler<CreateEventCommand, int>
    {
        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event(request.Name, request.Description, request.Country, request.StartDate, 10);

            var result = await eventsRepository.AddAsync(newEvent);

            return result;
        }
    }
}
