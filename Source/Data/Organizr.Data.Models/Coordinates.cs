namespace Organizr.Data.Models
{
    using Organizr.Data.Common.Models;

    public class Coordinates : BaseModel<int>
    {
        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
