namespace Organizr.Web.Areas.Events.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;
    using ViewModels;
    using Web.Controllers;

    public class DetailsController : BaseController
    {
        private IEventsServices eventsServices;
        private IUsersServices usersServices;

        public DetailsController(IEventsServices eventsServices, IUsersServices usersServices)
        {
            this.eventsServices = eventsServices;
            this.usersServices = usersServices;
        }

        // GET: Events/Details/ById/{id}
        public ActionResult ById(string id)
        {
            var eventById = this.eventsServices.GetById(id);

            var eventModel = this.Mapper.Map<EventDetailsViewModel>(eventById);

            return this.View(eventModel);
        }

        [Authorize]
        public ActionResult Join(string id)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.usersServices.GetAll().Where(x => x.Id == id).FirstOrDefault();

            var eventData = this.eventsServices.AddUserToEvent(id, user);
            var eventForView = this.Mapper.Map<EventDetailsViewModel>(eventData);

            return this.View("ById", eventForView);
        }
    }
}