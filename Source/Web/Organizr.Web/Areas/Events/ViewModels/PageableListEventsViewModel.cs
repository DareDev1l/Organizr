namespace Organizr.Web.Areas.Events.ViewModels
{
    using System.Collections.Generic;

    public class PageableListEventsViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ListEventsViewModel> Events { get; set; }
    }
}