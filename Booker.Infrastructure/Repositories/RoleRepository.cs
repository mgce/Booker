using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booker.Core.Domain;
using Booker.Core.Repositories;

namespace Booker.Infrastructure.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public Task<Role> GetByName(string name)
        {
            using (var dataContext = new BookerContext())
            {
                return dataContext.Set<Role>().SingleOrDefaultAsync(r => r.Name == name);
            }
        }
    }
}
