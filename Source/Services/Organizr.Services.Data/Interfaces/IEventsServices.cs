namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;
    using System.Threading.Tasks;

    public interface IEventsServices
    {
        Event CreateEvent(Event eventToRegister);

        IQueryable<Event> GetAll();

        Event GetById(string urlId);

        Event GetById(int id);

        void Delete(Event eventToDelete);

        Task<Event> AddUserToEvent(string eventId, User user);

        void Update(Event eventToUpdate);
    }
}
