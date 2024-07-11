namespace EventBooking.Application.Errors
{
    public class EventDoesNotExistsError : IError
    {
        public string ErrorMessage => "Event does not exists.";
    }
}
