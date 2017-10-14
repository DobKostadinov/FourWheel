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

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UserDetailsViewModel, User>()
                .ForMember(userDb => userDb.UserName, cfg => cfg.MapFrom(userDetailsView => userDetailsView.Username))
                .ForMember(userDb => userDb.Email, cfg => cfg.MapFrom(userDetailsView => userDetailsView.Email))
                .ForMember(userDb => userDb.PhoneNumber, cfg => cfg.MapFrom(userDetailsView => userDetailsView.PhoneNumber))
                .ForMember(userDb => userDb.FullName, cfg => cfg.MapFrom(userDetailsView => userDetailsView.FullName));
        }
    }
}