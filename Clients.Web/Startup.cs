using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clients.Web.Startup))]
namespace Clients.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
