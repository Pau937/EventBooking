using EventBooking.Application.Errors;
using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using MediatR;

namespace EventBooking.Application.Commands.Events
{
    public class DeleteEventCommandHandler(IEventRepository eventsRepository) : IRequestHandler<DeleteEventCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var ev = await eventsRepository.GetByIdAsync(request.Id);

            if (ev is null)
            {
                return new Result<bool>(new EventDoesNotExistsError());
            }

            var result = await eventsRepository.DeleteAsync(ev);

            return new Result<bool>(result);
        }
    }
}
