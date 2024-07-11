using EventBooking.API.Dtos;
using EventBooking.Application.Commands.Events;
using EventBooking.Application.Queries.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string? country, int take = 20, int skip = 0)
        {
            var result = await sender.Send(new GetEventsQuery(country, take, skip));

            var dtos = await result.Value!.Events.Select(x => new EventBasicDto(x.Name, x.Country, x.StartDate)).ToListAsync();

            return Ok(dtos);
        }

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            var result = await sender.Send(new CreateEventCommand(dto.Name, dto.Description, dto.Country, dto.StartDate, dto.NumberOfSeats));

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.ErrorMessage);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Value }, result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEventDto dto)
        {
            var result = await sender.Send(new UpdateEventCommand(dto.Id, dto.Name, dto.Description, dto.Country, dto.StartDate, dto.NumberOfSeats));

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.ErrorMessage);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await sender.Send(new DeleteEventCommand(id));

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.ErrorMessage);
            }

            return NoContent();
        }
    }
}
