using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Booker.Api.Controllers;
using Booker.Infrastructure;
using Booker.Infrastructure.Identity.Stores;
using Booker.Infrastructure.IoC.Modules;
using Microsoft.AspNet.Identity;
using Booker.Infrastructure.Identity;

namespace Booker.Api
{
    public static class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UsersController>().InstancePerRequest();


            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new MapperModule());
            builder.RegisterModule(new CommandModule());

            builder.RegisterType<BookerContext>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserStore<IdentityUser, Guid>>().InstancePerLifetimeScope();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}