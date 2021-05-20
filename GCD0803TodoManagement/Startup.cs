using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCD0803TodoManagement.Startup))]
namespace GCD0803TodoManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
