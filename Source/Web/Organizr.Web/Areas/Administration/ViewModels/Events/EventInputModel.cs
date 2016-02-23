namespace Organizr.Web.Areas.Administration.ViewModels.Events
{
    using System;

    public class EventInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
    }
}