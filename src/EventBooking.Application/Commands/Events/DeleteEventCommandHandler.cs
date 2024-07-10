using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class DeleteEventCommandHandler(IRepository<Event> eventsRepository) : IRequestHandler<DeleteEventCommand, bool>
    {
        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var ev = await eventsRepository.GetByIdAsync(request.Id);

            if (ev is null)
            {
                return false;
            }

            return await eventsRepository.DeleteAsync(ev);
        }
    }
}
