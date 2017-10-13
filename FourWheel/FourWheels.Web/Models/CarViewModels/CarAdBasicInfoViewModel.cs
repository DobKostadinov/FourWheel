using AutoMapper;
using FourWheels.Data.Models;
using FourWheels.Web.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourWheels.Web.Models.CarViewModels
{
    public class CarAdBasicInfoViewModel : IMapFrom<CarAd>, IHaveCustomMappings
    {
        public string CarAdId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public int ManufactureYear { get; set; }

        public string CarFuel { get; set; }

        public string ImageURL { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CarAd, CarAdBasicInfoViewModel>()
                 .ForMember(carAdBasic => carAdBasic.CarAdId, cfg => cfg.MapFrom(carAdDb => carAdDb.Id))
                .ForMember(carAdBasic => carAdBasic.Brand, cfg => cfg.MapFrom(carAdDb => carAdDb.CarModel.CarBrand.Brand))
                .ForMember(carAdBasic => carAdBasic.Model, cfg => cfg.MapFrom(carAdDb => carAdDb.CarModel.Model))
                .ForMember(carAdBasic => carAdBasic.Price, cfg => cfg.MapFrom(carAdDb => carAdDb.Price))
                .ForMember(carAdBasic => carAdBasic.ManufactureYear, cfg => cfg.MapFrom(carAdDb => carAdDb.ManufactureYear))
                .ForMember(carAdBasic => carAdBasic.CarFuel, cfg => cfg.MapFrom(carAdDb => carAdDb.FuelType.ToString()))
                .ForMember(carAdBasic => carAdBasic.ImageURL, cfg => cfg.MapFrom(carAdDb => carAdDb.CarImageURL));
        }
    }
}