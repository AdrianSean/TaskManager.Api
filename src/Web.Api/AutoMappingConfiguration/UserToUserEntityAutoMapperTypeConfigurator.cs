using AutoMapper;
using Common.TypeMapping;
using Data.Entities;

namespace Web.Api.AutoMappingConfiguration
{
    public class UserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, User>()
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}