using FourWheels.Common;
using FourWheels.Data.Models;
using FourWheels.Data.Models.Enums;
using FourWheels.Web.Infrastructure.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FourWheels.Web.Models.CarViewModels
{
    public class CarAdInputModel : IMapFrom<CarAd>
    {
        [Required]
        [MinLength(DataModelsConstants.MinLengthAdTitle, 
            ErrorMessage = ErrorMessages.LengthEqualOrGreater)]
        [MaxLength(DataModelsConstants.MaxLengthAdTitle,
            ErrorMessage = ErrorMessages.LengthEqualOrLess)]
        [Display(Name = "Ad title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Car model")]
        public string CarModelId { get; set; }

        [Required]
        [EnumDataType(typeof(CarType))]
        [Display(Name = "Car type")]
        public CarType CarType { get; set; }

        [Required]
        [Display(Name = "Manufacture year")]
        [Range(DataModelsConstants.MinManufactureYear,
            DataModelsConstants.MaxManufactureYear,
            ErrorMessage = ErrorMessages.RangeShouldBeBetween)]
        public int ManufactureYear { get; set; }

        [Required]
        [Range(DataModelsConstants.MinCarMileage,
            DataModelsConstants.MaxCarMileage,
            ErrorMessage = ErrorMessages.RangeShouldBeBetween)]
        public int Mileage { get; set; }

        [Required]
        [EnumDataType(typeof(FuelType))]
        [Display(Name = "Fuel")]
        public FuelType FuelType { get; set; }

        [Required]
        [EnumDataType(typeof(TransmissionType))]
        [Display(Name = "Transmission")]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        [Display(Name = "Car features")]
        public IList<CarFeatureInputViewModel> CarFeatures { get; set; }

        [Required]
        [Display(Name = "Choose town")]
        public string TownId { get; set; }

        [Required]
        [Range(DataModelsConstants.MinCarPrice,
            DataModelsConstants.MaxCarPrice,
            ErrorMessage = ErrorMessages.RangeShouldBeBetween)]
        [Display(Name = "Car price")]
        public double Price { get; set; }

        [Required]
        [MinLength(DataModelsConstants.MinLengthAdditionalInfo,
            ErrorMessage = ErrorMessages.LengthEqualOrGreater)]
        [MaxLength(DataModelsConstants.MaxLengthAdditionalInfo,
            ErrorMessage = ErrorMessages.LengthEqualOrLess)]
        [Display(Name = "Additional information")]
        public string AdditionalInfo { get; set; }

        [Display(Name = "Car image URL")]
        [Required]
        public string CarImageUrl { get; set; }
    }
}