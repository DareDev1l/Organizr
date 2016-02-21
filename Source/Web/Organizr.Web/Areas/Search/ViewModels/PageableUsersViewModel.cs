namespace Organizr.Web.Areas.Search.ViewModels
{
    using System.Collections.Generic;

    public class PageableUsersViewModel
    {
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}