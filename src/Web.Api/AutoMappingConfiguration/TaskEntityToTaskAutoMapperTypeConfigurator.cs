using AutoMapper;
using Common.TypeMapping;
using Data.Entities;


namespace Web.Api.AutoMappingConfiguration
{
    public class TaskEntityToTaskAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Task, Models.Task>()
                .ForMember(opt=>opt.Links, x=>x.Ignore())
                .ForMember(opt => opt.Assignees, x => x.Ignore());
        }
    }
}