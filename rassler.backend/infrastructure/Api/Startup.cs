using Microsoft.Owin;
using Owin;
using rassler.backend.infrastructure.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace rassler.backend.infrastructure.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
