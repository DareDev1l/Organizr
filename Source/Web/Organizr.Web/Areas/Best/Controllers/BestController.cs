namespace Organizr.Web.Areas.Best.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using MvcTemplate.Services.Data;
    using ViewModels;
    using Web.Controllers;

    public class BestController : BaseController
    {
        private IEventsServices events;

        public BestController(IEventsServices events)
        {
            this.events = events;
        }

        public ActionResult Best()
        {
            var events = this
                            .events
                            .GetAll()
                            .To<BestEventsViewModel>()
                            .ToList()
                            .OrderByDescending(x => x.Rate)
                            .Take(10);

            return this.View(events);
        }
    }
}