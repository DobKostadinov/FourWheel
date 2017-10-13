using AutoMapper;
using FourWheels.Common;
using FourWheels.Data.Models;
using FourWheels.Data.Models.Enums;
using FourWheels.Web.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FourWheels.Web.Models.CarViewModels
{
    public class CarAdInputModel : IMapFrom<CarAd>/*, IHaveCustomMappings*/
    {
        [Required]
        [MinLength(DataModelsConstants.MinLengthAdTitle)]
        [MaxLength(DataModelsConstants.MaxLengthAdTitle)]
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
        [Display(Name = "Manufacture Year(From 1930 and 2017)")]
        [Range(
            DataModelsConstants.MinManufactureYear,
            DataModelsConstants.MaxManufactureYear,
            ErrorMessage = "Manufacture year should be between 1950 and 2017")]
        public int ManufactureYear { get; set; }

        [Required]
        [Range(
            DataModelsConstants.MinCarMileage,
            DataModelsConstants.MaxCarMileage)]
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
        [Range(
            DataModelsConstants.MinCarPrice,
            DataModelsConstants.MaxCarPrice)]
        [Display(Name = "Car price")]
        public double Price { get; set; }

        [Required]
        [MinLength(DataModelsConstants.MinLengthAdditionalInfo)]
        [MaxLength(DataModelsConstants.MaxLengthAdditionalInfo)]
        public string AdditionalInfo { get; set; }

        public string CarImageUrl { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<CarInputModel, Car>()
        //        .ForMember(cardb => cardb.CarModelId, cfg => cfg.MapFrom(carView => carView.CarModelId))
        //        .ForMember(cardb => cardb.ManufactureYear, cfg => cfg.MapFrom(carView => carView.ManufactureYear))
        //        .ForMember(cardb => cardb.Mileage, cfg => cfg.MapFrom(carView => carView.Mileage))
        //        .ForMember(cardb => cardb.CarType, cfg => cfg.MapFrom(carView => carView.CarType))
        //        .ForMember(cardb => cardb.FuelType, cfg => cfg.MapFrom(carView => carView.FuelType))
        //        .ForMember(cardb => cardb.TransmissionType, cfg => cfg.MapFrom(carView => carView.TransmissionType))
        //        .ForMember(cardb => cardb.CarFeatures, cfg => cfg.MapFrom(carView => carView.CarFeatures.Where(x => x.IsChecked == true)))
        //        .ForMember(cardb => cardb.CarImageURL, cfg => cfg.MapFrom(carView => carView.CarImageUrl));
        //}
    }
}