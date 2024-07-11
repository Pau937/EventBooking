using Asp.Versioning;
using EventBooking.API.Dtos;
using EventBooking.Application.Commands.Events;
using EventBooking.Application.Models;
using EventBooking.Application.Queries.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventBooking.API.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class EventsController(ISender sender) : ControllerBase
    {
        [ProducesResponseType(typeof(PagedList<EventBasicDto>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> Get(string? country, int take = 20, int skip = 0)
        {
            var result = await sender.Send(new GetEventsQuery(country, take, skip));
            var pagedListDto = new PagedListDto<EventBasicDto>(result.Value!.Values.Select(x => new EventBasicDto(x.Name, x.Country, x.StartDate)), result.Value.Total);

            return Ok(pagedListDto);
        }

        [ProducesResponseType(typeof(EventDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sender.Send(new GetEventByIdQuery(id));

            if (result.Value is null)
            {
                return NotFound($"There is no event with the given id: {id}.");
            }

            var dto = new EventDto(result.Value.Name, result.Value.Description, result.Value.Country, result.Value.StartDate, result.Value.NumberOfSeats);

            return Ok(dto);
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            dto.StartDate = ToUtcTime(dto.StartDate);

            var result = await sender.Send(new CreateEventCommand(dto.Name, dto.Description, dto.Country, dto.StartDate, dto.NumberOfSeats));

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.ErrorMessage);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Value }, result.Value);
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEventDto dto)
        {
            dto.StartDate = ToUtcTime(dto.StartDate);

            var result = await sender.Send(new UpdateEventCommand(dto.Id, dto.Name, dto.Description, dto.Country, dto.StartDate, dto.NumberOfSeats));

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.ErrorMessage);
            }

            return NoContent();
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await sender.Send(new DeleteEventCommand(id));

            if (result.IsFailure)
            {
                return NotFound(result.Error!.ErrorMessage);
            }

            return NoContent();
        }

        private static DateTime ToUtcTime(DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
    }
}
