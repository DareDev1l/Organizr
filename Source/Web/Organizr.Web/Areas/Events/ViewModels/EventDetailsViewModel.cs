namespace Organizr.Web.Areas.Events.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Infrastructure.Mapping;
    using Organizr.Data.Models;
    using Services.Web;

    public class EventDetailsViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User Organiser { get; set; }

        public DateTime? StartDate { get; set; }

        public Location Location { get; set; }

        public LocationOnMap LocationOnMap { get; set; }

        public bool HasFinished { get; set; }

        public ICollection<User> Candidates { get; set; }

        public ICollection<User> Participants { get; set; }

        public string EncodedId
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return identifier.EncodeId(this.Id);
            }
        }
    }
}