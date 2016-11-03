namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using Organizr.Data.Models;
    using System.Threading.Tasks;

    public interface IUsersServices
    {
        IQueryable<User> GetAll();

        Task AddUserToFriends(User sender, User receiver);

        Task Update(User user);

        User GetUserById(string id);
    }
}
