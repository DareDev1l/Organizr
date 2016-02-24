namespace Organizr.Web.Areas.Events.Controllers
{
    using System;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;
    using Organizr.Data.Models;
    using Organizr.Services.Web;
    using Organizr.Web.Areas.Events.ViewModels;

    [Authorize]
    public class CreateController : Controller
    {
        private IEventsServices eventsServices;

        public CreateController(IEventsServices eventsServices)
        {
            this.eventsServices = eventsServices;
        }

        // GET: Events/Create
        public ActionResult Event()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CreateEventViewModel eventToRegister)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(eventToRegister);
            }

            var userId = this.User.Identity.GetUserId();

            var eventToCreate = new Event()
            {
                Name = eventToRegister.Name,
                Description = eventToRegister.Description,
                CreatedOn = DateTime.Now,
                StartDate = eventToRegister.StartDate,
                OrganiserId = userId,
                Coordinates = eventToRegister.Coordinates,
                LocationId = 1
            };

            var createdEvent = this.eventsServices.CreateEvent(eventToCreate);
            IIdentifierProvider provider = new IdentifierProvider();
            string encodedId = provider.EncodeId(createdEvent.Id);

            return this.Redirect("~/Events/" + encodedId);
        }
    }
}