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
        public async Task<User> GetAsync(string email)
        {
            using (var dataContext = new BookerContext())
            {
                return await dataContext.Set<User>()
                    .SingleOrDefaultAsync(u => u.Email == email);
            }
        }
    }
}
