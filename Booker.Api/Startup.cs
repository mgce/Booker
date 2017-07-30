using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Booker.Api.Startup))]

namespace Booker.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}