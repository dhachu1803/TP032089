using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaerskContainerWebApp.Startup))]
namespace MaerskContainerWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
