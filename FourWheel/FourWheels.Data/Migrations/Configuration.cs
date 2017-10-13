using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;

using FourWheels.Data.DbContexts;
using FourWheels.Data.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;

namespace FourWheels.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FourWheelsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FourWheelsSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.ImportTowns(context);
            this.ImportBrandsAndModels(context);
            this.ImportCarFeatures(context);
        }

        private void SeedAdmin(FourWheelsSqlDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void ImportTowns(FourWheelsSqlDbContext context)
        {
            if (!context.Towns.Any())
            {
                using (WebClient client = new WebClient())
                {
                    string townsAsJsonStr = client.DownloadString("https://api.myjson.com/bins/10p8s9");

                    JArray towns = JArray.Parse(townsAsJsonStr);

                    foreach (var town in towns)
                    {
                        var townName = town["city"].ToString();
                        var newTown = new Town
                        {
                            Name = townName
                        };

                        context.Towns.AddOrUpdate(newTown);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void ImportBrandsAndModels(FourWheelsSqlDbContext context)
        {
            if (!context.CarBrands.Any() &&
                !context.CarModels.Any())
            {
                using (WebClient client = new WebClient())
                {
                    string brandsAndModelsAsString = client.DownloadString("https://api.myjson.com/bins/1es58p");

                    JArray brandsAndModels = JArray.Parse(brandsAndModelsAsString);

                    foreach (var brandModels in brandsAndModels)
                    {
                        var brand = brandModels["brand"].ToString();
                        var newBrand = new CarBrand
                        {
                            Brand = brand
                        };

                        context.CarBrands.AddOrUpdate(newBrand);

                        var models = brandModels["models"];

                        foreach (var model in models)
                        {
                            var modelName = model.ToString();
                            var newModel = new CarModel
                            {
                                Model = modelName,
                                CarBrandId = newBrand.Id,
                            };


                            context.CarModels.AddOrUpdate(newModel);
                        }

                        context.SaveChanges();
                    }
                }
            }
        }

        private void ImportCarFeatures(FourWheelsSqlDbContext context)
        {
            if (!context.CarFeatures.Any())
            {
                using (WebClient client = new WebClient())
                {
                    string carFeaturesJsonStr = client.DownloadString("https://api.myjson.com/bins/ysw4x");

                    JArray carFeature = JArray.Parse(carFeaturesJsonStr);

                    foreach (var feature in carFeature)
                    {
                        var newFeature = new CarFeature
                        {
                            Name = feature.ToString()
                        };

                        context.CarFeatures.AddOrUpdate(newFeature);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
