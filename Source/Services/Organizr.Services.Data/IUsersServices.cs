namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;

    public interface IUsersServices
    {
        IQueryable<User> GetAll();

        void AddUserToFriends(User sender, User receiver);

        void Update(User user);

        User GetUserById(string id);
    }
}
