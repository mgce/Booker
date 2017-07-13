using Autofac;
using Booker.Core.Repositories;
using Booker.Infrastructure.Repositories;

namespace Booker.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}