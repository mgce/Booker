using Booker.Core.Domain;
using Booker.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        public async Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User user)
        {
            
        }

        public async Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
        }
    }
}
