using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeasIntoCodeFirstVersion.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Developer> Developers { get; set; }


        public DbSet<Comment> Comments { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Follow> Follows { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<DeveloperNotification> DeveloperNotifications { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Team> Teams { get; set; }
        //public DbSet<TeamDeveloper> TeamDevelopers{ get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public ApplicationDbContext()
            : base("IdeasIntoCodeFirstVersionContext", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.Developer)
                .WithMany(c => c.Comments)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Receiver)
                .WithMany(m => m.RecievedMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany(m => m.SendMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Developer>()
                .HasMany(d => d.Followers)
                .WithRequired(d => d.Followee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Developer>()
                .Property(d => d.BirthDate)
                .HasColumnType("datetime2");






            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}