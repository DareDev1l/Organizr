namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Organizr.Data.Common;
    using Organizr.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class UsersService : IUsersServices
    {
        private readonly UserStore<User> store;

        public UsersService(DbContext dbContext)
        {
            this.store = new UserStore<User>(dbContext);
        }

        public async Task AddUserToFriends(User sender, User receiver)
        {
            sender.Friends.Add(receiver);
            receiver.Friends.Add(sender);

            await this.store.UpdateAsync(sender);
            await this.store.UpdateAsync(receiver);

            this.SaveChanges();
        }

        public User GetUserById(string id)
        {
            return this.store.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<User> GetAll()
        {
            return this.store.Users;
        }

        public async Task Update(User user)
        {
            await this.store.UpdateAsync(user);

            this.SaveChanges();
        }

        public async Task SaveChanges()
        {
            this.store.Context.SaveChanges();
        }
    }
}
