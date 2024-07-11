namespace EventBooking.Application.Errors
{
    public class RegistrationAlreadyExistsError : IError
    {
        public string ErrorMessage => "The registration already exists.";
    }
}
