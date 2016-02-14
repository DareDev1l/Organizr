namespace Organizr.Web.Areas.Events.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using MvcTemplate.Services.Data;
    using ViewModels;

    public class ListController : Controller
    {
        private IEventsServices eventsServices;

        public ListController(IEventsServices eventsServices)
        {
            this.eventsServices = eventsServices;
        }

        // GET: Events/List
        public ActionResult Index()
        {
            var events = this.eventsServices.GetAll().To<ListEventsViewModel>().ToList();

            return this.View(events);
        }
    }
}