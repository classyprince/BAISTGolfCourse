using System.Web.Mvc;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Data.Entity;
using System.Web.Security;
using BAISTGolfCourse.Common.AutoMapper;
using BAISTGolfCourse.Data;
using BAISTGolfCourse.BLL.ServiceImpl;
using BAISTGolfCourse.BLL.ServiceInterfaces;

namespace BAISTGolfCourse.Web.WindsorConfiguration
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
         
            //Register all controllers
            container.Register(
                //All services
                Classes.FromAssembly(Assembly.GetAssembly(typeof(IApplicantService))).
                    InSameNamespaceAs<ApplicantService>().WithService.DefaultInterfaces().LifestylePerWebRequest(),

                //All MVC controllers
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient(),

                 //All DbContexts
                 Component.For<DbContext>()
                                    .ImplementedBy<ClubBAISTEntities>()
                                    .LifestylePerWebRequest(),

               //All AutoMapper Classes
               Component.For<IAutoMapper>().ImplementedBy<AutoMapperAdapter>().LifestyleTransient()
                );
                
            //Register Facilities
            container.AddFacility<EntityFrameWorkRelatedFacility>();
            container.AddFacility<GeneralFacility>();


        }

    }
}