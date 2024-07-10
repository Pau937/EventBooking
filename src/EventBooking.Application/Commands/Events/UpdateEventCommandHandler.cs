using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class UpdateEventCommandHandler(IRepository<Event> eventsRepository) : IRequestHandler<UpdateEventCommand, bool>
    {
        public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await eventsRepository.GetByIdAsync(request.Id);

            if (entity is null)
            {
                return false;
            }

            entity.Update(request.Name, request.Description, request.Country, request.StartDate, request.NumberOfSeats);

            return await eventsRepository.UpdateAsync(entity);
        }
    }
}
