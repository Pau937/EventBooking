using EventBooking.API.Dtos;
using EventBooking.Application.Commands.Registrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationsController(ISender sender) : ControllerBase
    {
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateRegistrationDto dto)
        {
            var result = await sender.Send(new CreateRegistrationToEventCommand(dto.Email, dto.EventId));

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.ErrorMessage);
            }

            return Created();
        }
    }
}
