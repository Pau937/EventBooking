using AutoMapper;
using EventBooking.API.Dtos;
using EventBooking.Application.Models;
using EventBooking.Domain.Models;

namespace EventBooking.API.AutoMapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<Event, EventBasicDto>();
            CreateMap<EventViewModel, EventBasicDto>();
        }
    }
}
