using System;

using FourWheels.Data.Models;
using FourWheels.Web.Infrastructure.Contracts;
using AutoMapper;
using System.Collections.Generic;

namespace FourWheels.Web.Models.CarViewModels
{
    public class CarFeatureViewModel : IMapFrom<CarFeature>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsChecked { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CarFeatureViewModel, CarFeature>()
                .ForMember(cardb => cardb.Id, cfg => cfg.MapFrom(carfeautureView => carfeautureView.Id))
                .ForMember(cardb => cardb.Name, cfg => cfg.MapFrom(carfeautureView => carfeautureView.Name));

            
        }
    }
}