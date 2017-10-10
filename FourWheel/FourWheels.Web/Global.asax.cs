using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using FourWheels.Web.App_Start;

namespace FourWheels.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            FourWheelsSqlDbConfig.Initialize();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutomapperConfig.Register();
        }
    }
}
