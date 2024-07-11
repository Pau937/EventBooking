using EventBooking.Application.Errors;
using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class CreateEventCommandHandler(IEventRepository eventsRepository) : IRequestHandler<CreateEventCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            if (await eventsRepository.IsNameExists(request.Name))
            {
                return new Result<int>(new EventNameAlreadyExistsError());
            }

            var newEvent = new Event(request.Name, request.Description, request.Country, request.StartDate, 10);

            var result = await eventsRepository.AddAsync(newEvent);

            return new Result<int>(result.Id);
        }
    }
}
