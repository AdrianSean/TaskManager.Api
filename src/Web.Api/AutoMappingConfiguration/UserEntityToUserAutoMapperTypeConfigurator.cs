using AutoMapper;
using Common.TypeMapping;
using Data.Entities;

namespace Web.Api.AutoMappingConfiguration
{
    public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Models.User>()
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}