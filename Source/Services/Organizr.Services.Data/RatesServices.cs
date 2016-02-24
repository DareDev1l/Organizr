namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Common;
    using Organizr.Data.Models;

    public class RatesServices : IRatesServices
    {
        private IDbRepository<EventRate> eventRates;

        public RatesServices(IDbRepository<EventRate> eventRates)
        {
            this.eventRates = eventRates;
        }

        public IQueryable<EventRate> All()
        {
            return this.eventRates.All();
        }

        public EventRate Create(EventRate eventRate)
        {
            this.eventRates.Add(eventRate);
            this.eventRates.Save();

            return eventRate;
        }

        public void Update(EventRate eventRate)
        {
            this.eventRates.Save();
        }
    }
}
