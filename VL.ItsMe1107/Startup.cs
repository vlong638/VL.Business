using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VL.ItsMe1107.Startup))]
namespace VL.ItsMe1107
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
