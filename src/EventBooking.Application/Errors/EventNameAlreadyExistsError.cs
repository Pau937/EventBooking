namespace EventBooking.Application.Errors
{
    public class EventNameAlreadyExistsError : IError
    {
        public string ErrorMessage => "The given name for the event already exists.";
    }
}
