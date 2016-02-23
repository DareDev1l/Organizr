namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Organizr.Common;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Add Default picture
                System.Drawing.Image img = System.Drawing.Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Pictures\\default-profile.png");
                byte[] bytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    bytes = ms.ToArray();
                }

                var defaultPic = new Image()
                {
                    Id = 1,
                    FileName = "default-profile",
                    Content = bytes,
                    FileExtension = "png"
                };

                context.Images.Add(defaultPic);
                context.SaveChanges();

                var location = new Location()
                {
                    Id = 1,
                    Name = "No location!",
                    Description = "No description!",
                    CreatedOn = DateTime.Now
                };

                context.Locations.Add(location);
                context.SaveChanges();

                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, FirstName = "Admin", LastName = "Admin", ImageId = 1 };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);

                for (int i = 1; i <= 15; i++)
                {
                    var eventToAdd = new Event()
                    {
                        Name = "Event " + i,
                        Description = "This is the description of event with number " + i,
                        Coordinates = new Coordinates() { Latitude = 10 + i, Longitude = 10 + i },
                        StartDate = DateTime.Now.AddDays(i),
                        LocationId = 1,
                        OrganiserId = user.Id
                    };

                    context.Events.Add(eventToAdd);
                }

                context.SaveChanges();
            }
        }
    }
}
