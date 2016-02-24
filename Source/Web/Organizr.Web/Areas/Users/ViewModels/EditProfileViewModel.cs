namespace Organizr.Web.Areas.Users.ViewModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EditProfileViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
    }
}