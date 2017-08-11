using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Booker.Api.Controllers;
using Booker.Infrastructure;
using Booker.Infrastructure.Identity.Stores;
using Booker.Infrastructure.IoC.Modules;
using Microsoft.AspNet.Identity;
using Booker.Infrastructure.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;

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

            builder.RegisterType<UserManager<IdentityUser, Guid>>()
               .As<UserManager<IdentityUser, Guid>>()
               .InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();


            builder.RegisterType<AccountController>().InstancePerRequest();
            //builder.RegisterApiControllers(typeof (Booker.Api).Assembly);

            builder.RegisterType<TicketSerializer>()
                    .As<IDataSerializer<AuthenticationTicket>>();
            builder.Register(c => new DpapiDataProtectionProvider().Create("ASP.NET Identity"))
                   .As<IDataProtector>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}