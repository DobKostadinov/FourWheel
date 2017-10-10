using System.Data.Entity;

using FourWheels.Data.DbContexts;
using FourWheels.Data.Migrations;

namespace FourWheels.Web.App_Start
{
    public class FourWheelsSqlDbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FourWheelsSqlDbContext, Configuration>());
        }
    }
}