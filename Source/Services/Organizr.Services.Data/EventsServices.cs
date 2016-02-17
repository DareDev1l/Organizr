namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Organizr.Data.Common;
    using Organizr.Data.Models;
    using Organizr.Services.Web;

    public class EventsServices : IEventsServices
    {
        private readonly IDbRepository<Event> events;
        private readonly IIdentifierProvider identifierProvider;

        public EventsServices(IDbRepository<Event> eventsRepository, IIdentifierProvider identifierProvider)
        {
            this.events = eventsRepository;
            this.identifierProvider = identifierProvider;
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

        public Event GetById(string urlId)
        {
            var intId = this.identifierProvider.DecodeId(urlId);
            var eventById = this.events.GetById(intId);

            return eventById;
        }

        public Event AddUserToEvent(string eventId, User user)
        {
            var eventToFind = this.GetById(eventId);
            eventToFind.Participants.Add(user);
            this.events.Save();

            return eventToFind;
        }
    }
}
