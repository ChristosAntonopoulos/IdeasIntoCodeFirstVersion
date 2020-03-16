using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdeasIntoCodeFirstVersion.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Follow> Follows { get; set; }

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

            modelBuilder.Entity<Developer>()
                .HasMany(d => d.Followers)
                .WithRequired(d => d.Followee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Developer>()
                .Property(d=>d.BirthDate)
                .HasColumnType("datetime2");




            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}