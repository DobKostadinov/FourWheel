using System;
using System.Data.Entity;
using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;

using FourWheels.Data.Models;
using FourWheels.Data.Models.Contracts;

namespace FourWheels.Data.DbContexts
{
    public class FourWheelsSqlDbContext : IdentityDbContext<User>, IFourWheelsSqlDbContext
    {
        public FourWheelsSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Ad> Ads { get; set; }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<CarBrand> CarBrands { get; set; }

        public virtual IDbSet<CarModel> CarModels { get; set; }

        public virtual IDbSet<CarFeature> CarFeatures { get; set; }

        public virtual IDbSet<CarImage> CarImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
                .HasOptional(i => i.CarImage)
                .WithRequired(a => a.Car);

            modelBuilder.Entity<Ad>()
                .HasOptional(i => i.Car)
                .WithRequired(a => a.Ad);
        }

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
