using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FourWheels.Web.Startup))]
namespace FourWheels.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
