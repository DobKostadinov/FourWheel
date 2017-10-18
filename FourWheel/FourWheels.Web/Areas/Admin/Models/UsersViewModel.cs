using AutoMapper;
using FourWheels.Data.Models;
using FourWheels.Web.Infrastructure.Contracts;

namespace FourWheels.Web.Areas.Admin.Models
{
    public class UsersDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public string IsDeleted { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<UsersDetailsViewModel, User>()
                .ForMember(userDb => userDb.Id, cfg => cfg.MapFrom(userDetailsView => userDetailsView.Id))
                .ForMember(userDb => userDb.UserName, cfg => cfg.MapFrom(userDetailsView => userDetailsView.Username))
                .ForMember(userDb => userDb.Email, cfg => cfg.MapFrom(userDetailsView => userDetailsView.Email))
                .ForMember(userDb => userDb.PhoneNumber, cfg => cfg.MapFrom(userDetailsView => userDetailsView.PhoneNumber))
                .ForMember(userDb => userDb.FullName, cfg => cfg.MapFrom(userDetailsView => userDetailsView.FullName))
                .ForMember(userDb => userDb.IsDeleted, cfg => cfg.MapFrom(userDetailsView => userDetailsView.IsDeleted));
        }
    }
}