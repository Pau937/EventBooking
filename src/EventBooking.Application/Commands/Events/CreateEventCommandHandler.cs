using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class CreateEventCommandHandler(IEventRepository eventsRepository) : IRequestHandler<CreateEventCommand, int>
    {
        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            if (await eventsRepository.IsNameExists(request.Name))
            {
                return 0;
            }

            var newEvent = new Event(request.Name, request.Description, request.Country, request.StartDate, 10);

            var result = await eventsRepository.AddAsync(newEvent);

            return result.Id;
        }
    }
}
