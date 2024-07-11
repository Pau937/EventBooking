using AutoMapper;
using EventBooking.API.Dtos;
using EventBooking.Application.Models;

namespace EventBooking.API.AutoMapper
{
    public class PagedListProfile : Profile
    {
        public PagedListProfile()
        {
            CreateMap<PagedList<EventViewModel>, PagedList<EventBasicDto>>();
        }
    }
}
