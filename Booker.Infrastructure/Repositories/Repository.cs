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
        public async Task<T> GetByIdAsync(Guid id)
        {
            using (var dataContext = new BookerContext())
            {
                return await dataContext.Set<T>().FindAsync(id);
            }       
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var dataContext = new BookerContext())
            {
                return await dataContext.Set<T>().ToListAsync();
            }
        }

        public async Task AddAsync(T entity)
        {
            using (var dataContext = new BookerContext())
            {
                dataContext.Set<T>().Add(entity);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(T entity)
        {
            using (var dataContext = new BookerContext())
            {
                dataContext.Set<T>().Remove(entity);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                using (var dataContext = new BookerContext())
                {
                    await dataContext.SaveChangesAsync();
                }
            }

        }

        public async Task SaveChangesAsync()
        {
            using (var dataContext = new BookerContext())
            {
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
