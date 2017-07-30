using AutoMapper;
using Booker.Core.Domain;
using Booker.Infrastructure.Identity;

namespace Booker.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()       
            => new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<User, UserDto>();
                //cfg.CreateMap<Booking, BookingDto>();
                cfg.CreateMap<User, IdentityUser>().ForMember(dest => dest.UserName,opt => opt.MapFrom(src => src.Username));
                cfg.CreateMap<Role, IdentityRole>();
            })
            .CreateMapper();      
    }

}
