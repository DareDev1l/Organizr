namespace Organizr.Web.Areas.Events.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventEditViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        [MinLength(5)]
        public string Name { get; set; }

        [MinLength(10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
    }
}