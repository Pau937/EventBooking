using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class CreateEventCommandHandler(IRepository<Event> eventsRepository) : IRequestHandler<CreateEventCommand, bool>
    {
        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event(request.Name, request.Description, request.Country, request.StartDate, 10);

            var result = await eventsRepository.Add(newEvent);

            return result;
        }
    }
}
