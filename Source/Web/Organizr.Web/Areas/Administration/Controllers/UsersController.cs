namespace Organizr.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using MvcTemplate.Services.Data;
    using ViewModels.Users;

    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private IUsersServices users;

        public UsersController(IUsersServices users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.users
                .GetAll()
                .To<UserViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }
    }
}