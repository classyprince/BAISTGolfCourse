using AutoMapper;
using BAISTGolfCourse.Common.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAISTGolfCourse.Web.App_Start
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurators)
        {
            autoMapperTypeConfigurators.ToList().ForEach(x => x.Configure());

            Mapper.AssertConfigurationIsValid();
        }
    }
}