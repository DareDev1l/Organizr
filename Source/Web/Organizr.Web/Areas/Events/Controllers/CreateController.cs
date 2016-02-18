using Microsoft.AspNet.Identity;
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
    public class CreateController : Controller
    {
        private IEventsServices eventsServices;

        public CreateController(IEventsServices eventsServices)
        {
            this.eventsServices = eventsServices;
        }

        // GET: Events/Create
        public ActionResult Index()
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
                LocationId = 2,
                StartDate = eventToRegister.StartDate,
                OrganiserId = userId
            };

            this.eventsServices.CreateEvent(eventToCreate);

            return this.RedirectToAction("List", "List");
        }
    }
}