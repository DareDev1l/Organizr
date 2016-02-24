namespace Organizr.Web.Areas.Users.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EditProfileViewModel : IMapFrom<User>
    {
        [Required]
        [StringLength(40, ErrorMessage = "The first name can not be longer than 40 characters!")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The last name can not be longer than 40 characters!")]
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
    }
}