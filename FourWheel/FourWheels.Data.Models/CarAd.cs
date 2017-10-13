using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FourWheels.Common;
using FourWheels.Data.Models.Abstracts;
using FourWheels.Data.Models.Enums;

namespace FourWheels.Data.Models
{
    public class CarAd : BaseDataModel
    {
        private ICollection<CarFeature> carFeatures;

        public CarAd()
        {
            this.carFeatures = new HashSet<CarFeature>();
        }

        [Required]
        [MinLength(DataModelsConstants.MinLengthAdTitle)]
        [MaxLength(DataModelsConstants.MaxLengthAdTitle)]
        public string Title { get; set; }

        [Required]
        [Range(
            DataModelsConstants.MinCarPrice,
            DataModelsConstants.MaxCarPrice)]
        public double Price { get; set; }

        [Required]
        [Range(
            DataModelsConstants.MinManufactureYear,
            DataModelsConstants.MaxManufactureYear)]
        public int ManufactureYear { get; set; }

        [Required]
        [Range(
            DataModelsConstants.MinCarMileage,
            DataModelsConstants.MaxCarMileage)]
        public int Mileage { get; set; }

        public Guid CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        [Required]
        [EnumDataType(typeof(CarType))]
        public CarType CarType { get; set; }

        [Required]
        [EnumDataType(typeof(FuelType))]
        public FuelType FuelType { get; set; }

        [Required]
        [EnumDataType(typeof(TransmissionType))]
        public TransmissionType TransmissionType { get; set; }

        public string CarImageURL { get; set; }

        public Guid TownId { get; set; }

        public virtual Town Town { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
        
        public virtual ICollection<CarFeature> CarFeatures
        {
            get { return this.carFeatures; }
            set { this.carFeatures = value; }
        }

        [Required]
        [MinLength(DataModelsConstants.MinLengthAdditionalInfo)]
        [MaxLength(DataModelsConstants.MaxLengthAdditionalInfo)]
        public string AdditionalInfo { get; set; }
    }
}
