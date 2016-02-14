namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;

    public interface IEventsServices
    {
        Event CreateEvent(Event eventToRegister);

        IQueryable<Event> GetAll();
    }
}
