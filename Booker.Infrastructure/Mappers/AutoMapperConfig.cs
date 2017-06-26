using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Booker.Core.Domain;
using Booker.Infrastructure.Dto;

namespace Booker.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()       
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Booking, BookingDto>();
            })
            .CreateMapper();
        
    }
}
