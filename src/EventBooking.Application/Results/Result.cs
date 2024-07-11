using EventBooking.Application.Errors;

namespace EventBooking.Application.Results
{
    public class Result<T>
    {
        public Result(IError error)
        {
            Error = error;
        }

        public Result(T value)
        {
            Value = value;
        }

        public bool IsFailure { get => Error is not null; }
        public T? Value { get; set; }
        public IError? Error { get; set; }
    }
}
