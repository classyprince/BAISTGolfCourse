using BAISTGolfCourse.Common.AutoMapper;
using BAISTGolfCourse.Data;
using BAISTGolfCourse.Web.App_Start;
using BAISTGolfCourse.Web.WindsorConfiguration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BAISTGolfCourse.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private WindsorContainer _windsorContainer;

        protected void Application_Start()
        {
            InitializeWindsor();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeDbMigrations();
            ConfigureAutoMapper();
        }

        private void InitializeDbMigrations()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClubBAISTEntities, Data.Migrations.Configuration>());
        }

        private void ConfigureAutoMapper()
        {
            new AutoMapperConfigurator().Configure(_windsorContainer.ResolveAll<IAutoMapperTypeConfigurator>());
        }

        protected void Application_End()
        {
            if (_windsorContainer != null)
            {
                _windsorContainer.Dispose();
            }
        }

        private void InitializeWindsor()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(FromAssembly.This());

            // clean up, application exits

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));

        }
    }
}
