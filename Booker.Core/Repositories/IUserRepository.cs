using Booker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booker.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);

        Task<User> GetAsync(string email);

        Task<IEnumerable<User>> GetAllAsync(); 

        Task AddAsync(User user);

        Task RemoveAsync(Guid id);

        Task UpdateAsync(User user);
    }
}
