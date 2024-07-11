using EventBooking.Application.Commands.Events;
using EventBooking.Application.Errors;
using EventBooking.Domain.DataAccess;
using EventBooking.Domain.Models;
using Moq;
using Xunit;

namespace EventsBooking.Application.Tests
{
    public class CreateEventCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnEvent_WhenEverythingIsOk()
        {
            //Arrange
            var repo = new Mock<IEventRepository>();

            repo.Setup(x => x.AddAsync(It.IsAny<Event>())).ReturnsAsync(new Event("Event", "Description", "Country", new DateTime(2022, 10, 10), 20));
            repo.Setup(x => x.IsNameExists(It.IsAny<string>())).ReturnsAsync(false);

            var handler = new CreateEventCommandHandler(repo.Object);
            var command = new CreateEventCommand("Event", "Description", "Country", new DateTime(2022, 10, 10), 20);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Error);
        }

        [Fact]
        public async Task Handle_ShouldReturnEventNameAlreadyExistsError_WhenEventNameAlreadyExists()
        {
            //Arrange
            var repo = new Mock<IEventRepository>();

            repo.Setup(x => x.IsNameExists(It.IsAny<string>())).ReturnsAsync(true);

            var handler = new CreateEventCommandHandler(repo.Object);
            var command = new CreateEventCommand("Event", "Description", "Country", new DateTime(2022, 10, 10), 20);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.NotNull(result.Error);
            Assert.IsType<EventNameAlreadyExistsError>(result.Error);
        }
    }
}
