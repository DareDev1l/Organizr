namespace Organizr.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;
    using ViewModels;
    using Web.Controllers;

    [Authorize]
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

        public ActionResult DetailsOf(string id)
        {
            var userId = this.User.Identity.GetUserId();
            var userToShow = this.Mapper
                                .Map<UserProfileViewModel>(this.usersServices.GetUserById(userId));

            return this.View(userToShow);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.usersServices.GetUserById(userId);

            var userModel = this.Mapper.Map<EditProfileViewModel>(user);

            return this.View(userModel);
        }

        [HttpPost]
        public ActionResult Edit(EditProfileViewModel profile)
        {
            var userId = this.User.Identity.GetUserId();
            var userToUpdate = this.usersServices.GetUserById(userId);
            userToUpdate.FirstName = profile.FirstName;
            userToUpdate.LastName = profile.LastName;

            this.usersServices.Update(userToUpdate);

            return this.Redirect("/Me");
        }
    }
}