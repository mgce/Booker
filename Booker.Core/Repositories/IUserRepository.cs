using Booker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booker.Core.Repositories
{
    public interface IUserRepository 
        : IRepository<User>
    {
        Task<User> GetAsync(string email);
    }
}
