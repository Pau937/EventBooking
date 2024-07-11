namespace EventBooking.API.Dtos
{
    public record PagedListDto<T>(IEnumerable<T> Values, int Total);
}
