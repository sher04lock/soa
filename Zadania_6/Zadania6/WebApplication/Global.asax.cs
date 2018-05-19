using Autofac;
using Autofac.Integration.WebApi;
using log4net.Core;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication.Services;

namespace WebApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<Logger>().As<Services.ILogger>().SingleInstance();

            builder.RegisterType<Repositories.FroEntityFramework.PaintingRepository>().As<IPaintingRepository>().SingleInstance();
            builder.RegisterType<Repositories.ForLiteDB.ArtistRepository>().As<IRepository<Artist>>().SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
