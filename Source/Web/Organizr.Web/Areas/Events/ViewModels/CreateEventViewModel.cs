namespace Organizr.Web.Areas.Events.ViewModels
{
    using Infrastructure.Mapping;
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    // TODO: Add location
    public class CreateEventViewModel : IMapFrom<Event>
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public LocationOnMap LocationOnMap { get; set; }
    }
}