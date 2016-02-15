namespace Organizr.Web.Areas.Events.Controllers
{
    using System.Web.Mvc;
    using MvcTemplate.Services.Data;
    using Organizr.Web.Infrastructure.Mapping;
    using ViewModels;
    using Web.Controllers;

    public class DetailsController : BaseController
    {
        private IEventsServices eventsServices;

        public DetailsController(IEventsServices eventsServices)
        {
            this.eventsServices = eventsServices;
        }

        // GET: Events/Details/ById/{id}
        public ActionResult ById(string id)
        {
            var eventById = this.eventsServices.GetById(id);

            var eventModel = this.Mapper.Map<EventDetailsViewModel>(eventById);

            return this.View(eventModel);
        }
    }
}