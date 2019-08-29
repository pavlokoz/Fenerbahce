using Fenerbahce.Controllers;
using Fenerbahce.DB.Setup;
using Fenerbahce.Infrastructure.Config;
using Fenerbahce.Infrastructure.Constants;
using Fenerbahce.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;

[assembly: OwinStartup(typeof(Fenerbahce.Startup))]
namespace Fenerbahce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.Setup(BaseConstants.ConnectionStrings.DatabaseConnectionString);
            ConfigureAuth(app);
            CreateUsers();
        }

        private void CreateUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new ApplicationUserManager(new UserStore(context));

            if (userManager.Users.Count() == 0)
            {
                var user = new ApplicationUser()
                {
                    UserName = "amin@gmail.com",
                    Email = "amin@gmail.com",
                    FirstName = "Amin",
                    LastName = "Fenerbahce",
                    EmailConfirmed = true,
                    DateOfBirth = null,
                    Roles =
                    {
                        new UserRole
                        {
                            RoleId = 1
                        }
                    },
                    SecurityPin = "1234"
                };

                IdentityResult result = userManager.Create(user, "Aa1111!!");
            }
        }
    }
}
