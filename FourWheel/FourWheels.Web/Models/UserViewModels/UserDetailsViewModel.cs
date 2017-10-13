using AutoMapper;
using FourWheels.Data.Models;
using FourWheels.Web.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourWheels.Web.Models.UserViewModels
{
    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserDetailsViewModel, User>()
                .ForMember(cardb => cardb.UserName, cfg => cfg.MapFrom(carfeautureView => carfeautureView.Username))
                .ForMember(cardb => cardb.Email, cfg => cfg.MapFrom(carfeautureView => carfeautureView.Email));


        }
    }
}