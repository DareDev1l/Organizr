namespace Organizr.Web.Areas.Users.Controllers
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Services.Data;

    public class ProfileImageController : Controller
    {
        private IImagesServices images;
        private IUsersServices users;

        public ProfileImageController(IImagesServices images, IUsersServices users)
        {
            this.images = images;
            this.users = users;
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var imageToAdd = new Image();

                using (var memory = new MemoryStream())
                {
                    file.InputStream.CopyTo(memory);
                    var byteArray = memory.GetBuffer();
                    var fileName = file.FileName;
                    var fileExtension = Path.GetExtension(fileName).Substring(1);

                    imageToAdd.FileName = fileName;
                    imageToAdd.Content = byteArray;
                    imageToAdd.FileExtension = fileExtension;
                }

                this.images.Create(imageToAdd);
                var userId = this.User.Identity.GetUserId();
                var currentUser = this.users.GetUserById(userId);
                currentUser.ImageId = imageToAdd.Id;
                this.users.Update(currentUser);
            }

            return this.Redirect("/Me");
        }
    }
}