namespace Organizr.Web.Areas.Events.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Infrastructure.Mapping;
    using Organizr.Data.Models;
    using Services.Web;

    public class ListEventsViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User Organiser { get; set; }

        public DateTime? StartDate { get; set; }

        public Location Location { get; set; }

        public bool HasFinished { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Events/{identifier.EncodeId(this.Id)}";
            }
        }
    }
}