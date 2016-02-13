using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(Organizr.Web.Startup))]

namespace Organizr.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
