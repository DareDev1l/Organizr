namespace Organizr.Web.Areas.Events.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;

    [Authorize]
    public class RatesController : Controller
    {
        private IRatesServices rates;
        private IEventsServices events;

        public RatesController(IRatesServices rates, IEventsServices events)
        {
            this.rates = rates;
            this.events = events;
        }

        // GET: Events/Rates
        public ActionResult Rate(int eventId, int value)
        {
            if (value < 1)
            {
                value = 1;
            }

            if (value > 5)
            {
                value = 5;
            }

            var userId = this.User.Identity.GetUserId();
            var rate = this.rates.All().FirstOrDefault(x => x.RaterId == userId && x.EventId == eventId);

            if (rate == null)
            {
                rate = new Data.Models.EventRate()
                {
                    RaterId = userId,
                    EventId = eventId,
                    Value = value
                };

                this.rates.Create(rate);

                var ratedEvent = this.events.GetById(eventId);
                ratedEvent.EventRates.Add(rate);
                this.events.Update(ratedEvent);
            }

            //var eventRatesCount = this.rates.All().Where(x => x.EventId == eventId).ToList().Count;
            //var eventRatesSum = this.rates.All().Where(x => x.EventId == eventId).Sum(x => x.Value);

            //decimal avgRating = (decimal)eventRatesCount / eventRatesSum;
            //var avgRatingString = string.Format("{0:0.00}", avgRating);


            return this.Json(new { RateValue = value });
        }
    }
}