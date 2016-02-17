namespace Organizr.Web.Areas.Events.Controllers
{
    using System.Web.Mvc;
    using MvcTemplate.Services.Data;
    using Organizr.Web.Infrastructure.Mapping;
    using ViewModels;
    using Web.Controllers;
    using Microsoft.AspNet.Identity;

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

        public ActionResult Join(string id)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.usersServices.GetUserById(userId);

            var eventData = this.eventsServices.AddUserToEvent(id, user);
            var eventForView = this.Mapper.Map<EventDetailsViewModel>(eventData);

            return this.View("ById", eventForView);
        }
    }
}