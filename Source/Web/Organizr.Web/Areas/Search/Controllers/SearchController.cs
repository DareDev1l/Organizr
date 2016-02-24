namespace Organizr.Web.Areas.Search.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;
    using ViewModels;
    using Data.Models;

    public class SearchController : Controller
    {
        private const int ItemsPerPage = 2;

        private IUsersServices usersServices;

        public SearchController(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        // GET: Search/Search
        public ActionResult SimpleSearch(string search = "", int page = 1)
        {
            /*
            if (!this.ModelState.IsValid)
            {
                this.TempData["Error"] = GlobalConstants.InvalidSearchString;
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request"); ;
            }
            */

            var itemsToSkip = (page - 1) * ItemsPerPage;

            var searcherId = this.User.Identity.GetUserId();

            this.ViewBag.SearcherId = searcherId;
            
                var users = this.usersServices
                              .GetAll()
                              .Where(x =>
                                  x.FirstName.ToLower().Contains(search.ToLower()) ||
                                  x.LastName.ToLower().Contains(search.ToLower()) ||
                                  x.Email.ToLower().Contains(search.ToLower()))
                              .OrderBy(x => x.FirstName)
                              .ThenBy(x => x.LastName)
                              .Skip(itemsToSkip)
                              .Take(ItemsPerPage)
                              .To<UserViewModel>()
                              .ToList();

            var allItemsCount = users.Count;
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

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