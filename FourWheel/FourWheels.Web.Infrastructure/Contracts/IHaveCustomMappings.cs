using AutoMapper;

namespace FourWheels.Web.Infrastructure.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
