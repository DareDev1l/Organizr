namespace Organizr.Web.Areas.Best.ViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class BestEventsViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User Organiser { get; set; }

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