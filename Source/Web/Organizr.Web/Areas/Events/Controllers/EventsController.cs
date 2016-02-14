using MvcTemplate.Services.Data;
using Organizr.Data.Models;
using Organizr.Web.Areas.Events.ViewModels;
using Organizr.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizr.Web.Areas.Events.Controllers
{
    public class EventsController : Controller
    {
        private IEventsServices eventsServices;

        public EventsController(IEventsServices eventsServices)
        {
            this.eventsServices = eventsServices;
        }

        // GET: Events/CreateEvent
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(CreateEventViewModel eventToRegister)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(eventToRegister);
            }

            var eventToCreate = new Event()
            {
                Name = eventToRegister.Name,
                Description = eventToRegister.Description,
                StartDate = DateTime.Now,
                LocationId = 3
            };

            this.eventsServices.CreateEvent(eventToCreate);

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult List()
        {
            var events = this.eventsServices.GetAll().To<ListEventsViewModel>().ToList();

            return this.View(events);
        }
    }
}