﻿namespace Organizr.Web.Areas.Events.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using MvcTemplate.Services.Data;
    using ViewModels;
    using Web.Controllers;

    public class ListController : BaseController
    {
        private IEventsServices eventsServices;

        public ListController(IEventsServices eventsServices)
        {
            this.eventsServices = eventsServices;
        }

        // GET: Events/List
        public ActionResult All()
        {
            var events = this.eventsServices
                                .GetAll()
                                .OrderByDescending(x => x.CreatedOn)
                                .To<ListEventsViewModel>()
                                .ToList();

            return this.View(events);
        }

        public ActionResult Filter(int page = 1, string contains = "", string from = "", string to = "")
        {
            const int ItemsPerPage = 5;

            var events = this.eventsServices.GetAll().To<ListEventsViewModel>().ToList();

            if (!string.IsNullOrEmpty(contains))
            {
                events = events.Where(x => x.Name.ToLower().Contains(contains.ToLower()) || x.Description.ToLower().Contains(contains.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(from))
            {
                var fromDate = DateTime.Parse(from);
                events = events.Where(x => x.StartDate >= fromDate).ToList();
            }

            if (!string.IsNullOrEmpty(to))
            {
                var toDate = DateTime.Parse(to);
                events = events.Where(x => x.StartDate <= toDate).ToList();
            }

            int filteredEventsCount = events.Count;

            int totalPages = (int)Math.Ceiling(filteredEventsCount / (decimal)ItemsPerPage);
            int itemsToSkip = (page - 1) * ItemsPerPage;

            var filteredEvents = events
                                    .Skip(itemsToSkip)
                                    .Take(ItemsPerPage)
                                    .ToList();

            var pageableListEventViewModel = new PageableListEventsViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Events = filteredEvents
            };

            return this.View(pageableListEventViewModel);
        }
    }
}