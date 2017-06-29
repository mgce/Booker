using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Booker.Api.Controllers;
using Booker.Infrastructure.Repositories;
using Booker.Infrastructure.Services;

namespace Booker.Api
{
    public static class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UsersController>().InstancePerRequest();


            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
           .Where(t => t.IsClass && t.Name.EndsWith("Service"))
           .As(t => t.GetInterfaces().Single(i => i.Name.EndsWith(t.Name)));
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
           .Where(t => t.IsClass && t.Name.EndsWith("Repository"))
           .As(t => t.GetInterfaces().Single(i => i.Name.EndsWith(t.Name)));
            //builder.RegisterModule<ServiceModule>();
            //builder.RegisterModule<RepositoryModule>();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }

    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineServicesAssembly).Assembly).AsImplementedInterfaces().InstancePerRequest();
            base.Load(builder);
        }
    }

    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineRepositoryAssembly).Assembly).AsImplementedInterfaces().InstancePerRequest();
            base.Load(builder);
        }
    }
}