namespace Organizr.Web.Areas.Events.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Organizr.Data.Models;
    using Infrastructure.Mapping;

    public class ListEventsViewModel : IMapFrom<Event>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public User Organiser { get; set; }

        public DateTime? StartDate { get; set; }

        public Location Location { get; set; }

        public bool HasFinished { get; set; }

        public ICollection<User> Candidates { get; set; }

        public ICollection<User> Participants { get; set; }
    }
}