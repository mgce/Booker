using Booker.Core.Domain;
using Booker.Core.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Booker.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<User> GetByEmailAsync(string email)
        {
            using (var dataContext = new BookerContext())
            {
                return await dataContext.Set<User>()
                    .SingleOrDefaultAsync(u => u.Email == email);
            }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            using (var dataContext = new BookerContext())
            {
                return await dataContext.Set<User>()
                    .SingleOrDefaultAsync(u => u.Username == username);
            }
        }
    }
}
