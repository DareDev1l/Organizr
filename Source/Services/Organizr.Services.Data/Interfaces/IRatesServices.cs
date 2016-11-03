namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;

    public interface IRatesServices
    {
        IQueryable<EventRate> All();

        void Update(EventRate eventRate);

        EventRate Create(EventRate eventRate);
    }
}
