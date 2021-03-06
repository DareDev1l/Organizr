﻿namespace Organizr.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Organizr.Data.Models;
    using Organizr.Data.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<LocationRate> LocationRates { get; set; }

        public IDbSet<Coordinates> Coordinates { get; set; }

        public IDbSet<EventRate> EventRates { get; set; }

        public IDbSet<FriendRequest> FriendRequests { get; set; }

        public IDbSet<Image> Images { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Participants)
                .WithMany(u => u.EventsParticipated)
                .Map(mc =>
                {
                    mc.ToTable("EventsUsers");
                    mc.MapLeftKey("EventId");
                    mc.MapRightKey("UserId");
                });

            modelBuilder.Entity<Event>()
                .HasRequired(ev => ev.Organiser)
                .WithMany(user => user.EventsOrganised);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
