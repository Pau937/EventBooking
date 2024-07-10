using EventBooking.API.Dtos;
using EventBooking.Application.Commands.Events;
using EventBooking.Application.Queries.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string? searchTerm, int take = 20, int skip = 0)
        {
            var result = await sender.Send(new GetEventsQuery(searchTerm, take, skip));

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sender.Send(new GetEventByIdQuery(id));

            if (result is null)
            {
                return NotFound($"There is no event with the given id: {id}.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            var result = await sender.Send(new CreateEventCommand(dto.Name, dto.Country, dto.Description, dto.StartDate, dto.NumberOfSeats));

            if (result)
            {
                return Created();
            }

            return Ok();
        }
    }
}
