using EventBooking.Domain.DataAccess;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class UpdateEventCommandHandler(IEventRepository eventsRepository) : IRequestHandler<UpdateEventCommand, bool>
    {
        public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await eventsRepository.GetByIdAsync(request.Id);

            if (entity is null)
            {
                return false;
            }

            if (await eventsRepository.IsNameExists(request.Name))
            {
                return false;
            }

            entity.Update(request.Name, request.Description, request.Country, request.StartDate, request.NumberOfSeats);

            return await eventsRepository.UpdateAsync(entity);
        }
    }
}
