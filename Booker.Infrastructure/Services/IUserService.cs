using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booker.Infrastructure.Dto;

namespace Booker.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(string email);

        Task RegisterAsync(string email, string username, string password);
    }
}
