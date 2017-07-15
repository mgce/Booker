using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booker.Core.Repositories;

namespace Booker.Infrastructure.Repositories
{
    public class Repository <T> : IRepository<T> where T:class
    {
        protected readonly BookerContext _context;

        protected Repository(BookerContext context)
        {
            _context = context;
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                await _context.SaveChangesAsync();
            }

        }
    }
}
