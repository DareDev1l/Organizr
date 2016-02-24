namespace Organizr.Web.Areas.Users.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserProfileViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string About { get; set; }

        public Image Image { get; set; }

        public DateTime BirthDay { get; set; }

        public ICollection<User> Friends { get; set; }

        public ICollection<Event> EventsOrganised { get; set; }

        public ICollection<Location> LocationsOwned { get; set; }

        public ICollection<Event> EventsParticipated { get; set; }

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