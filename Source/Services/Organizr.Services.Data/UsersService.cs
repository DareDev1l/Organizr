namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Organizr.Data.Common;
    using Organizr.Data.Models;

    public class UsersService : IUsersServices
    {
        private readonly IDbRepository<User> users;

        public UsersService(DbRepository<User> users)
        {
            this.users = users;
        }

        public void AddUserToFriends(User sender, User receiver)
        {
            sender.Friends.Add(receiver);
            this.Update(sender);
            receiver.Friends.Add(sender);
            this.Update(receiver);
        }

        public User GetUserById(string id)
        {
            return this.users.All().Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public void Update(User user)
        {
            this.users.Save();
        }
    }
}
