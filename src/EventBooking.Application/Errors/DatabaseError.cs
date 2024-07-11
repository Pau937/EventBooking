namespace EventBooking.Application.Errors
{
    public class DatabaseError : IError
    {
        public string ErrorMessage => "Database error.";
    }
}
