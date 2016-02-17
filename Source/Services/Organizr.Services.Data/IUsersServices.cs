namespace MvcTemplate.Services.Data
{
    using Organizr.Data.Models;

    public interface IUsersServices
    {
        User GetUserById(string id);
    }
}
