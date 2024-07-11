using Asp.Versioning;
using AutoMapper;
using EventBooking.API.Dtos;
using EventBooking.Application.Commands.Events;
using EventBooking.Application.Models;
using EventBooking.Application.Queries.Events;
using EventBooking.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventBooking.API.Controllers
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class EventsController(ISender sender, IMapper mapper) : ControllerBase
    {
        [ProducesResponseType(typeof(PagedList<EventBasicDto>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> Get(string? country, int take = 20, int skip = 0)
        {
            var result = await sender.Send(new GetEventsQuery(country, take, skip));

            var pagedListDto = mapper.Map<PagedList<EventViewModel>, PagedList<EventBasicDto>>(result.Value!);

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

            var dto = mapper.Map<Event, EventDto>(result.Value);

            return Ok(dto);
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            var result = await sender.Send(new CreateEventCommand(dto.Name.Trim(), dto.Description, dto.Country, ToUtcTime(dto.StartDate), dto.NumberOfSeats));

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
            var result = await sender.Send(new UpdateEventCommand(dto.Id, dto.Name.Trim(), dto.Description, dto.Country, ToUtcTime(dto.StartDate), dto.NumberOfSeats));

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
