using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Queries.Events
{
    public class GetEventByIdQueryHandler(IRepository<Event> eventRepository) : IRequestHandler<GetEventByIdQuery, Result<Event?>>
    {
        public async Task<Result<Event?>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await eventRepository.GetByIdAsync(request.Id);

            return new Result<Event?>(result);
        }
    }
}
