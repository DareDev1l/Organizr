namespace Organizr.Web.Areas.Events.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Organizr.Data.Models;
    using Organizr.Data.Models;

    // TODO: Add location
    public class CreateEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }
    }
}