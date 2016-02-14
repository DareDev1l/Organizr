namespace MvcTemplate.Services.Data
{
    using Organizr.Data.Models;

    public interface IEventsServices
    {
        Event CreateEvent(Event eventToRegister);
    }
}
