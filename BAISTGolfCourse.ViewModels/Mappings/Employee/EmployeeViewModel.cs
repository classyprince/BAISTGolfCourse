using AutoMapper;
using BAISTGolfCourse.Common.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.ViewModels.Mappings.Employee
{
    public class EmployeeViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Models.Employee, ViewModels.Employee.EmployeeViewModel>();
        }
    }
}
