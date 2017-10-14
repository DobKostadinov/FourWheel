using System.Collections.Generic;
using System.Linq;

using FourWheels.Data.Models;
using FourWheels.Data.Models.Enums;
using System;

namespace FourWheels.Services.Contracts
{
    public interface ICarAdServices : IService
    {
        IQueryable<CarAd> GetAll();

        IQueryable<CarAd> GetLastFiveAddedAds();

        CarAd GetAdById(Guid id);

        void AddNewCarAd(
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
            string userId);

        void DeleteAd(Guid id);
    }
}
