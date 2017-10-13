using Bytes2you.Validation;
using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FourWheels.Services
{
    public class CarFeaturesServices : ICarFeatureServices
    {
        private readonly IEfRepostory<CarFeature> carFeaturesRepo;

        public CarFeaturesServices(IEfRepostory<CarFeature> carFeaturesRepo)
        {
            Guard.WhenArgument(carFeaturesRepo, "carFeaturesRepo").IsNull().Throw();

            this.carFeaturesRepo = carFeaturesRepo;
        }

        public IQueryable<CarFeature> GetAllCarFeatures()
        {
            return this.carFeaturesRepo.All;
        }
    }
}
