using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Booker.Api.Controllers;
using Booker.Core.Domain;
using Booker.Infrastructure.IoC.Modules;

namespace Booker.Api
{
    public static class AutofacConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UsersController>().InstancePerRequest();


            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new MapperModule());
            builder.RegisterModule(new CommandModule());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}