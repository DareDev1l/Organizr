namespace Organizr.Web.Areas.Search.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}