using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VL.Facade1.Startup))]
namespace VL.Facade1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
