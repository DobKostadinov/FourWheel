using System.Linq;
using System.Collections.Generic;

using FourWheels.Data.Models;
using FourWheels.Data.Repositories;
using FourWheels.Data.UnitOfWork;
using FourWheels.Services.Contracts;

using Bytes2you.Validation;
using System;
using FourWheels.Data.Models.Enums;

namespace FourWheels.Services
{
    public class CarAdServices : ICarAdServices
    {
        private readonly IEfRepostory<CarAd> carsAdsRepo;
        private readonly IEfRepostory<CarBrand> carBrandsRepo;
        private readonly IEfRepostory<CarModel> carModelsRepo;
        private readonly ICarFeatureServices carFeatureServices;
        private readonly IEfUnitOfWork unitOfWork;

        public CarAdServices(
            IEfRepostory<CarAd> carAdsRepo,
            IEfRepostory<CarBrand> carBrandsRepo,
            IEfRepostory<CarModel> carModelsRepo,
            ICarFeatureServices carFeatureServices,
            IEfUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(carAdsRepo, "carAdsRepo").IsNull().Throw();
            Guard.WhenArgument(carBrandsRepo, "carBrandsRepo").IsNull().Throw();
            Guard.WhenArgument(carModelsRepo, "carModelsRepo").IsNull().Throw();
            Guard.WhenArgument(carFeatureServices, "carFeatureServices").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.carsAdsRepo = carAdsRepo;
            this.carBrandsRepo = carBrandsRepo;
            this.carModelsRepo = carModelsRepo;
            this.carFeatureServices = carFeatureServices;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<CarAd> GetAll()
        {
            return this.carsAdsRepo.All;
        }

        public CarAd GetAdById(Guid id)
        {
           return this.carsAdsRepo.All.FirstOrDefault(x => x.Id == id);
        }



        public void AddNewCarAd(
           string title,
           Guid carModelId,
           CarType carType,
           int manufactureYear,
           int mileage,
           FuelType fuelType,
           TransmissionType transmissionType,
           IEnumerable<string> carFeatures,
           Guid townId,
           double price,
           string additionalInfo,
           string carImageUrl,
           string userId)
        {
            var allCarFeaturesFromDB = this.carFeatureServices.GetAllCarFeatures();

            var carFeaturesIn = new List<CarFeature>();

            foreach (var featureId in carFeatures)
            {
                var futureIdGuid = Guid.Parse(featureId);
                var feature = allCarFeaturesFromDB.FirstOrDefault(x => x.Id == futureIdGuid);
                carFeaturesIn.Add(feature);
            }

            var newCarAd = new CarAd
            {
                Title = title,
                CarModelId = carModelId,
                CarType = carType,
                ManufactureYear = manufactureYear,
                Mileage = mileage,
                FuelType = fuelType,
                TransmissionType = transmissionType,
                CarFeatures = carFeaturesIn,
                TownId = townId,
                Price = price,
                AdditionalInfo = additionalInfo,
                CarImageURL = carImageUrl,
                UserId = userId
            };

            this.carsAdsRepo.Add(newCarAd);
            this.unitOfWork.Commit();
        }
    }
}
