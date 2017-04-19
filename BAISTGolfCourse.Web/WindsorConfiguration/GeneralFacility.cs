using BAISTGolfCourse.ViewModels.Mappings.Applicant;
using BAISTGolfCourse.Common.AutoMapper;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using BAISTGolfCourse.ViewModels.Mappings.Employee;
using BAISTGolfCourse.ViewModels.Mappings.Member;
using BAISTGolfCourse.ViewModels.Mappings.Reservation;

namespace BAISTGolfCourse.Web.WindsorConfiguration
{
    public class GeneralFacility : AbstractFacility
    {
        protected override void Init()
        {
            //ViewModels
            Kernel.Register(Component.For<IAutoMapperTypeConfigurator>()
                 .ImplementedBy<CreateInputModel>(),
                 Component.For<IAutoMapperTypeConfigurator>()
                 .ImplementedBy<EmployeeViewModel>(),
                 Component.For<IAutoMapperTypeConfigurator>()
                 .ImplementedBy<MemberViewModel>(),
                  Component.For<IAutoMapperTypeConfigurator>()
                 .ImplementedBy<ReservationViewModel>());
        }
    }
}