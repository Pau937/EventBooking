using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Subscriptions
{
    public class CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionsRepository) : IRequestHandler<CreateSubscriptionCommand, bool>
    {
        public async Task<bool> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (await subscriptionsRepository.IsSubscriptionExists(request.Email, request.EventId))
            {
                return false;
            }

            var newSubscription = new Subscription(request.EventId, request.Email);

            var result = await subscriptionsRepository.AddAsync(newSubscription);

            //TODO: fix that ;) 
            return result.Id == 0;
        }
    }
}
