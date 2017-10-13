using System;
using System.Data.Entity;
using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;

using FourWheels.Data.Models;
using FourWheels.Data.Models.Contracts;

namespace FourWheels.Data.DbContexts
{
    public class FourWheelsSqlDbContext : IdentityDbContext<User>
    {
        public FourWheelsSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<CarAd> CarAds { get; set; }

        public virtual IDbSet<CarBrand> CarBrands { get; set; }

        public virtual IDbSet<CarModel> CarModels { get; set; }

        public virtual IDbSet<CarFeature> CarFeatures { get; set; }

        public static FourWheelsSqlDbContext Create()
        {
            return new FourWheelsSqlDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
