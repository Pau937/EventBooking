namespace EventBooking.Application.Errors
{
    public class SubscriptionAlreadyExistsError : IError
    {
        public string ErrorMessage => "The subscription already exists.";
    }
}
