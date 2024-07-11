using EventBooking.Domain.Models;
using Xunit;

namespace EventBooking.Domain.Tests
{
    public class EventTests
    {
        [Fact]
        public void Constructor_ShouldReturnNewEvent_WhenDataMeetsBusinessRequirements()
        {
            //Act
            var ev = new Event("Event", "This is an event", "Poland", new DateTime(2024, 10, 10), 100);

            //Assert
            Assert.NotNull(ev);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(101)]
        public void Constructor_ShouldThrowArgumentException_WhenNumberOfSeatsIsBelowOrAboveTheLimit(int numberOfSeats)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new Event("Event", "This is an event", "Poland", new DateTime(2024, 10, 10), numberOfSeats));
        }

        [Theory]
        [InlineData("            ")]
        [InlineData("")]
        [InlineData("This name is exactly 51 characters long not passed.")]
        public void Constructor_ShouldThrowArgumentException_WhenNameIsIncorrect(string name)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new Event(name, "This is an event", "Poland", new DateTime(2024, 10, 10), 100));
        }

        [Theory]
        [InlineData("            ")]
        [InlineData("")]
        [InlineData("Country 21 characters")]
        public void Constructor_ShouldThrowArgumentException_WhenCountryIsIncorrect(string country)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new Event("Event", "This is an event", country, new DateTime(2024, 10, 10), 100));
        }
    }
}
