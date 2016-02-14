namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Organizr.Data.Common;
    using Organizr.Data.Models;

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

        public IQueryable<Event> GetAll()
        {
            return this.events.All();
        }
    }
}
