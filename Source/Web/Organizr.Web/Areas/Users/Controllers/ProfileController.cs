namespace Organizr.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;
    using ViewModels;
    using Web.Controllers;

    public class ProfileController : BaseController
    {
        private IUsersServices usersServices;

        public ProfileController(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        public ActionResult Details()
        {
            var userId = this.User.Identity.GetUserId();
            var userToShow = this.Mapper
                                .Map<UserProfileViewModel>(this.usersServices.GetUserById(userId));

            return this.View(userToShow);
        }
    }
}