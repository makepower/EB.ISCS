using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EB.ISCS.Admin.Startup))]
namespace EB.ISCS.Admin
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
