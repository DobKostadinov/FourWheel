using AutoMapper;
using FourWheels.Data.Models;
using FourWheels.Web.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourWheels.Web.Models.CarViewModels
{
    public class CarAdFullInfoViewModel : IMapFrom<CarAd>, IHaveCustomMappings
    {
        public string Brand { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int ManufactureYear { get; set; }

        public string Model { get; set; }

        public int Mileage { get; set; }

        public string CarType { get; set; }

        public string FuelType { get; set; }

        public string TransmissionType { get; set; }

        public string CarImageURL { get; set; }

        public string Town { get; set; }

        public ICollection<string> CarFeatures { get; set; }

        public string AdditionalInfo { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CarAd, CarAdFullInfoViewModel>()
                .ForMember(carAdFull => carAdFull.Brand, cfg => cfg.MapFrom(carAdDb => carAdDb.CarModel.CarBrand.Brand))
                .ForMember(carAdFull => carAdFull.Title, cfg => cfg.MapFrom(carAdDb => carAdDb.Title))
                .ForMember(carAdFull => carAdFull.Price, cfg => cfg.MapFrom(carAdDb => carAdDb.Price))
                .ForMember(carAdFull => carAdFull.ManufactureYear, cfg => cfg.MapFrom(carAdDb => carAdDb.ManufactureYear))
                .ForMember(carAdFull => carAdFull.Model, cfg => cfg.MapFrom(carAdDb => carAdDb.CarModel.Model))
                .ForMember(carAdFull => carAdFull.Mileage, cfg => cfg.MapFrom(carAdDb => carAdDb.Mileage))
                .ForMember(carAdFull => carAdFull.CarType, cfg => cfg.MapFrom(carAdDb => carAdDb.CarType))
                .ForMember(carAdFull => carAdFull.FuelType, cfg => cfg.MapFrom(carAdDb => carAdDb.FuelType))
                .ForMember(carAdFull => carAdFull.TransmissionType, cfg => cfg.MapFrom(carAdDb => carAdDb.TransmissionType))
                .ForMember(carAdFull => carAdFull.CarImageURL, cfg => cfg.MapFrom(carAdDb => carAdDb.CarImageURL))
                .ForMember(carAdFull => carAdFull.Town, cfg => cfg.MapFrom(carAdDb => carAdDb.Town.Name))
                .ForMember(carAdFull => carAdFull.CarFeatures, cfg => cfg.MapFrom(carAdDb => carAdDb.CarFeatures.Select(x => x.Name)))
                .ForMember(carAdFull => carAdFull.AdditionalInfo, cfg => cfg.MapFrom(carAdDb => carAdDb.AdditionalInfo));

        }
    }
}