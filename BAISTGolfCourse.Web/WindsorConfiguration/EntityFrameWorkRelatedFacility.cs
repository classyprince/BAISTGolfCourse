using BAISTGolfCourse.Repositories.IRepositories;
using BAISTGolfCourse.Repositories.Repositories;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BAISTGolfCourse.Web.WindsorConfiguration
{
    public class EntityFrameWorkRelatedFacility : AbstractFacility
    {
        protected override void Init()
        {
            //Repositories
            Kernel.Register(Classes.FromAssembly(Assembly.GetAssembly(typeof(IApplicantRepository))).
                    InSameNamespaceAs<ApplicantRepository>().WithService.DefaultInterfaces().LifestylePerWebRequest());
        }
    }
}