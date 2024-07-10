namespace EventBooking.API.Dtos
{
    public record EventDto(string Name, string Description, string Country, DateTime StartDate, int NumberOfSeats);
}
