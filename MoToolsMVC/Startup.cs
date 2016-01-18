using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoToolsMVC.Startup))]
namespace MoToolsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
