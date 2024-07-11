using EventBooking.API.Dtos;
using EventBooking.Application.Commands.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] CreateSubscriptionDto dto)
        {
            var result = await sender.Send(new CreateSubscriptionCommand(dto.Email, dto.EventId));

            if (result)
            {
                return Created();
            }

            return BadRequest("Something went wrong.");
        }
    }
}
