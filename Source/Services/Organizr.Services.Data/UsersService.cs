namespace MvcTemplate.Services.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Organizr.Data.Models;

    public class UsersService : IUsersServices
    {
        public UsersService(DbContext context)
        {
            this.Context = context;
        }

        private DbContext Context { get; }

        public User GetUserById(string id)
        {
            var userManager = new UserManager<User>(new UserStore<User>(this.Context));
            var user = userManager.FindById(id);
            return user;
        }

        public IQueryable<User> GetAll()
        {
            var userManager = new UserManager<User>(new UserStore<User>(this.Context));
            var users = userManager.Users;

            return users;
        }

        public void AddUserToFriends(User sender, User receiver)
        {
            receiver.Friends.Add(sender);
            sender.Friends.Add(receiver);
            this.Context.SaveChanges();
        }
    }
}
