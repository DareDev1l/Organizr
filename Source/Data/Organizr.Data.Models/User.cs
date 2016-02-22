namespace Organizr.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Organizr.Data.Models;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Event> eventsOrganised;
        private ICollection<Event> eventsParticipated;
        private ICollection<Location> locationsOwned;
        private ICollection<User> friends;
        private ICollection<FriendRequest> friendRequests;

        public User()
        {
            this.eventsOrganised = new HashSet<Event>();
            this.eventsParticipated = new HashSet<Event>();
            this.locationsOwned = new HashSet<Location>();
            this.friends = new HashSet<User>();
            this.friendRequests = new HashSet<FriendRequest>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public DateTime? BirthDay { get; set; }

        public ICollection<User> Friends
        {
            get
            {
                return this.friends;
            }

            set
            {
                this.friends = value;
            }
        }

        public ICollection<FriendRequest> FriendRequests
        {
            get
            {
                return this.friendRequests;
            }

            set
            {
                this.friendRequests = value;
            }
        }

        public ICollection<Event> EventsOrganised
        {
            get
            {
                return this.eventsOrganised;
            }

            set
            {
                this.eventsOrganised = value;
            }
        }

        public ICollection<Event> EventsParticipated
        {
            get
            {
                return this.eventsParticipated;
            }

            set
            {
                this.eventsParticipated = value;
            }
        }

        public ICollection<Location> LocationsOwned
        {
            get
            {
                return this.locationsOwned;
            }

            set
            {
                this.locationsOwned = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
