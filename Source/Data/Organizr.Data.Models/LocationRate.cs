namespace MvcTemplate.Data.Models
{
    using Organizr.Data.Common.Models;
    using Organizr.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class LocationRate : BaseModel<int>
    {
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Range(1,10)]
        public double Value { get; set; }
    }
}