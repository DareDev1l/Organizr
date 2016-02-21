namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;

    public interface IUsersServices
    {
        User GetUserById(string id);

        IQueryable<User> GetAll();
    }
}
