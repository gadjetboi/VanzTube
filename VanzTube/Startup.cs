using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VanzTube.Startup))]
namespace VanzTube
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
