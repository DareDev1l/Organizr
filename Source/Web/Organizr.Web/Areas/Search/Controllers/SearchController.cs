namespace Organizr.Web.Areas.Search.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using MvcTemplate.Services.Data;
    using ViewModels;
    using Microsoft.AspNet.Identity;

    public class SearchController : Controller
    {
        private const int ItemsPerPage = 2;

        private IUsersServices usersServices;

        public SearchController(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        // GET: Search/Search
        public ActionResult SimpleSearch(SearchViewModel model, int page = 1)
        {
            if(!this.ModelState.IsValid)
            {
                this.TempData["Error"] = GlobalConstants.InvalidSearchString;
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request"); ;
            }
            
            var allItemsCount = this.usersServices.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var searcherId = this.User.Identity.GetUserId();

            this.ViewBag.SearcherId = searcherId;

            var users = this.usersServices.GetAll()
                .Where(x => x.Email.ToLower().Contains(model.Text.ToLower()))
                .OrderBy(x => x.Email)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .To<UserViewModel>()
                .ToList();

            var modelToReturn = new PageableUsersViewModel()
            {
                TotalPages = totalPages,
                CurrentPage = page,
                Users = users
            };

            return this.View(modelToReturn);
        }
    }
}