using Booker.Core.Domain;
using Booker.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace Booker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly BookerContext _context;

        protected UserRepository(BookerContext context)
        {
            _context = context;
        }


        public async Task<User> GetAsync(Guid id)
        {
            return _context.Set<User>().Find(id);
        }

        public async Task<User> GetAsync(string email)
        { 
            return _context.Set<User>()
                .AsQueryable()
                .SingleOrDefault(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return _context.Set<User>().ToList();
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
