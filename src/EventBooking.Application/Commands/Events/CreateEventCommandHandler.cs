using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, bool>
    {
        public Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var ev = new Event(0, request.Name, request.Country, request.Description, request.StartDate, 10);

            return Task.FromResult(true);
        }
    }
}
