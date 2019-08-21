using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fenerbahce.Models.IdentityModels
{
    public class UserRole : IdentityUserRole<int> { }
    public class UserClaim : IdentityUserClaim<int> { }
    public class UserLogin : IdentityUserLogin<int> { }

    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }

    public class ApplicationUser : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string SecurityPin { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            this.SecurityStamp = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class UserStore : UserStore<ApplicationUser, Role,
    int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role,
    int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
            : base("FenerbahceDBConnectionString")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Ignore(p => p.LockoutEnabled);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Ignore(p => p.LockoutEndDateUtc);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Ignore(p => p.PhoneNumber);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Ignore(p => p.PhoneNumberConfirmed);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Ignore(p => p.TwoFactorEnabled);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Ignore(p => p.SecurityStamp);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Ignore(p => p.AccessFailedCount);
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.SecurityPin).HasColumnName("SecurityPin");
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.Email).
                HasColumnName("Email").IsRequired().HasColumnAnnotation("Index",
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("MailIndex")
                    {
                        IsUnique = true
                    }
                }));
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.UserName).
                HasColumnName("FullName").IsRequired().HasColumnAnnotation("Index",
                new IndexAnnotation(new[]
                {
                    new IndexAttribute("NameIndex")
                    {
                        IsUnique = false
                    }
                }));
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.FirstName).
                HasColumnName("FirstName").IsRequired();
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.LastName).
                HasColumnName("LastName").IsRequired();
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.DateOfBirth).
                HasColumnName("DateOfBirth").IsOptional();

            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<Role>().ToTable("Role");
        }
    }
}
