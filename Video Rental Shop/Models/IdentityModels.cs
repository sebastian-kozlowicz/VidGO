using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Video_Rental_Shop.Enumerators;

namespace Video_Rental_Shop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public Roles UserRole { get; set; }

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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Game> Games { get; set; }
        public  DbSet<GamePlatform> GamePlatforms { get; set; }

        public ApplicationDbContext()
            : base("name=DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Membership>()
                        .Property(m => m.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Customer>()
                        .HasRequired(c => c.Membership)
                        .WithRequiredPrincipal(m => m.Customer)
                        .WillCascadeOnDelete(true);
        }
    }
}