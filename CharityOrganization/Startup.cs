using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharityOrganization.Startup))]
namespace CharityOrganization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
