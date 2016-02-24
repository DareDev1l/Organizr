namespace Organizr.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class EventRate : BaseModel<int>
    {
        public int EventId { get; set; }

        public Event Event { get; set; }

        public string RaterId { get; set; }

        public User Rater { get; set; }

        [Range(1,5)]
        public int Value { get; set; }
    }
}
