namespace Organizr.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using MvcTemplate.Services.Data;
    using ViewModels.Events;

    [Authorize(Roles = "Administrator")]
    public class EventsController : Controller
    {
        private IEventsServices events;

        public EventsController(IEventsServices events)
        {
            this.events = events;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Events_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.events
                .GetAll()
                .To<EventViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Update([DataSourceRequest]DataSourceRequest request, EventInputModel eventUpdate)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.events.GetAll().FirstOrDefault(x => x.Id == eventUpdate.Id);
                entity.Name = eventUpdate.Name;
                entity.Description = eventUpdate.Description;
                entity.StartDate = eventUpdate.StartDate;
                this.events.Update(entity);
            }

            return this.Json(new[] { eventUpdate }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Destroy([DataSourceRequest]DataSourceRequest request, Event eventToDelete)
        {
            this.events.Delete(eventToDelete);

            return this.Json(new[] { eventToDelete }.ToDataSourceResult(request, this.ModelState));
        }
    }
}