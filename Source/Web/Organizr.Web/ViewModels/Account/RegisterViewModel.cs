namespace Organizr.Web.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The user name can not be longer than 40 characters!")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "The user name can not be longer than 40 characters!")]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
    }
}
