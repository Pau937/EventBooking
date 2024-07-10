﻿using EventBooking.Domain.Models;

namespace EventBooking.Application.Queries.Events.Responses
{
    public class GetEventsQueryResponse
    {
        public GetEventsQueryResponse(IQueryable<Event> events)
        {
            Events = events;
            Total = events.Count();
        }

        public IQueryable<Event> Events { get; private set; }
        public int Total { get; private set; }
    }
}