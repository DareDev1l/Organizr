namespace Organizr.Web.Areas.Administration.ViewModels.Events
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CoordinatesViewModel : IMapFrom<Coordinates>
    {
        public string Id { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}