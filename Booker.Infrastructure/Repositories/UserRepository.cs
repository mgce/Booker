using Booker.Core.Domain;
using Booker.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace Booker.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BookerContext context) 
            : base(context)
        {
        }

        public async Task<User> GetAsync(string email)
        {
            return await _context.Set<User>()
                .Where(u => u.Email == email)
                .SingleOrDefaultAsync<User>();
        }
    }
}
