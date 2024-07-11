using EventBooking.Application.Errors;
using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class UpdateEventCommandHandler(IEventRepository eventsRepository) : IRequestHandler<UpdateEventCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await eventsRepository.GetByIdAsync(request.Id);

            if (entity is null)
            {
                return new Result<bool>(new EventDoesNotExistsError());
            }

            if (await eventsRepository.IsNameExists(request.Name))
            {
                return new Result<bool>(new EventNameAlreadyExistsError());
            }

            entity.Update(request.Name, request.Description, request.Country, request.StartDate, request.NumberOfSeats);

            var result = await eventsRepository.UpdateAsync(entity);

            return new Result<bool>(result);
        }
    }
}
