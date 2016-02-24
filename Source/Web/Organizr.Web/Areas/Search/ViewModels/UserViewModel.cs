namespace Organizr.Web.Areas.Search.ViewModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Image Image { get; set; }

        public string ImageSrc
        {
            get
            {
                var base64 = Convert.ToBase64String(this.Image.Content);
                var imgSrc = string.Format("data:image/{0};base64,{1}", this.Image.FileExtension, base64);

                return imgSrc;
            }
        }
    }
}