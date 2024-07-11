using EventBooking.Application.Errors;
using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Subscriptions
{
    public class CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionsRepository) : IRequestHandler<CreateSubscriptionCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (await subscriptionsRepository.IsSubscriptionExists(request.Email, request.EventId))
            {
                return new Result<bool>(new SubscriptionAlreadyExistsError());
            }

            var newSubscription = new Subscription(request.EventId, request.Email);

            var result = await subscriptionsRepository.AddAsync(newSubscription);

            //TODO: fix that ;) 
            return new Result<bool>(result.EventId > 0);
        }
    }
}
