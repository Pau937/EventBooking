﻿using EventBooking.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Domain.Models
{
    public sealed class Event : Entity
    {
        public Event(string name, string description, string country, DateTime startDay, int numberOfSeats)
        {
            Name = name;
            Country = country;
            Description = description;
            StartDay = startDay;
            NumberOfSeats = numberOfSeats;
        }

        public void Update(string name, string description, string country, DateTime startDay, int numberOfSeats)
        {
            Name = name;
            Description = description;
            Country = country;
            StartDay = startDay;
            NumberOfSeats = numberOfSeats;
        }

        public string Name { get; private set; }
        public string Country { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDay { get; private set; }
        public int NumberOfSeats { get; private set; }
    }
}
