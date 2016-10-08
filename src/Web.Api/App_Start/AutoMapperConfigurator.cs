using AutoMapper;
using Common.TypeMapping;
using System.Collections.Generic;
using System.Linq;

namespace Web.Api
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurator)
        {
            autoMapperTypeConfigurator.ToList().ForEach(x=>x.Configure());

            Mapper.AssertConfigurationIsValid();
        }
    }
}