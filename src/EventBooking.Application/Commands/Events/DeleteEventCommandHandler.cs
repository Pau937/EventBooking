using EventBooking.Domain.DataAccess;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class DeleteEventCommandHandler(IEventRepository eventsRepository) : IRequestHandler<DeleteEventCommand, bool>
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
