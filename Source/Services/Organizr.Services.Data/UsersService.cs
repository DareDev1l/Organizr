namespace MvcTemplate.Services.Data
{
    using System;
    using Organizr.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Organizr.Data;
    using System.Data.Entity;

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
    }
}
