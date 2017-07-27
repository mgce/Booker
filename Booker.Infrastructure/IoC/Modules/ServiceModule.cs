using Autofac;
using Booker.Infrastructure.Services;

namespace Booker.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<Encrypter>().As<IEncrypter>().InstancePerRequest();
            base.Load(builder);
        }
    }
}