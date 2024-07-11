namespace EventBooking.Application.Errors
{
    public class EventNameAlreadyExistsError : IError
    {
        public string ErrorMessage => "Given name for the event already exists";
    }
}
