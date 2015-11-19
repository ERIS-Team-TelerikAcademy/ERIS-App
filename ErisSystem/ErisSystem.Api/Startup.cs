using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ErisSystem.Api.Startup))]

namespace ErisSystem.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
