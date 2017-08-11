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
            builder.RegisterType<BookingRepository>().As<IBookingRepository>().InstancePerRequest();
            builder.RegisterType<ClaimRepository>().As<IClaimRepository>().InstancePerRequest();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerRequest();
            builder.RegisterType<ExternalLoginRepository>().As<IExternalLoginRepository>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}