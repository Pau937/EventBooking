using EventBooking.Application.Errors;
using EventBooking.Application.Results;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using MediatR;

namespace EventBooking.Application.Commands.Registrations
{
    public class CreateRegistrationToEventCommandHandler(IRegistrationRepository registrationsRepository) : IRequestHandler<CreateRegistrationToEventCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateRegistrationToEventCommand request, CancellationToken cancellationToken)
        {
            if (await registrationsRepository.IsRegistrationExists(request.Email, request.EventId))
            {
                return new Result<string>(new RegistrationAlreadyExistsError());
            }

            var newRegistration = new Registration(request.EventId, request.Email);

            var result = await registrationsRepository.AddAsync(newRegistration);

            return new Result<string>($"{result.Email}:{result.EventId}");
        }
    }
}
