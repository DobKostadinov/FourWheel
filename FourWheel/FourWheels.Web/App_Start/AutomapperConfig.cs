using System.Reflection;

namespace FourWheels.Web.App_Start
{
    public class AutomapperConfig
    {
        public static void Register()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}