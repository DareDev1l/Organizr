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
        private readonly IUsersServices users;
        private readonly IIdentifierProvider identifierProvider;

        public EventsServices(IDbRepository<Event> eventsRepository, IIdentifierProvider identifierProvider, IUsersServices users)
        {
            this.events = eventsRepository;
            this.identifierProvider = identifierProvider;
            this.users = users;
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

        public Event GetById(int id)
        {
            var eventById = this.events.GetById(id);

            return eventById;
        }

        public void Delete(Event eventToDelete)
        {
            this.events.Delete(eventToDelete);
            this.events.Save();
        }

        public Event AddUserToEvent(string eventId, User user)
        {
            var eventToFind = this.GetById(eventId);
            eventToFind.Participants.Add(user);
            this.events.Save();

            var eventToAdd = this.GetById(eventId);

            user.EventsParticipated.Add(eventToAdd);
            this.users.Update(user);

            return eventToFind;
        }

        public void Update(Event eventToUpdate)
        {
            this.events.Save();
        }
    }
}
