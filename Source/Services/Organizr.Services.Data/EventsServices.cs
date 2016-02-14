using System;
using Organizr.Data.Models;
using Organizr.Data.Common;

namespace MvcTemplate.Services.Data
{
    public class EventsServices : IEventsServices
    {
        private IDbRepository<Event> events;

        public EventsServices(IDbRepository<Event> eventsRepository)
        {
            this.events = eventsRepository;
        }

        public Event CreateEvent(Event eventToRegister)
        {
            this.events.Add(eventToRegister);
            this.events.Save();

            return eventToRegister;
        }
    }
}
