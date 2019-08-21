using Fenerbahce.DB.Setup;
using Fenerbahce.Infrastructure.Constants;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Fenerbahce.Startup))]

namespace Fenerbahce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.Setup(BaseConstants.ConnectionStrings.DatabaseConnectionString);
            ConfigureAuth(app);
        }
    }
}
