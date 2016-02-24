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

        public Coordinates Coordinates { get; set; }

        public bool HasFinished { get; set; }

        public ICollection<User> Participants { get; set; }

        public ICollection<EventRate> EventRates { get; set; }

        public decimal Rate
        {
            get
            {
                if (this.EventRates.Count == 0)
                {
                    return 0;
                }

                decimal sum = 0;

                foreach (var rate in this.EventRates)
                {
                    sum += rate.Value;
                }

                decimal avgRate = sum / this.EventRates.Count;

                return avgRate;
            }
        }

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