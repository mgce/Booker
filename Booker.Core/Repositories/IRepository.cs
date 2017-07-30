﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booker.Core.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task RemoveAsync(T entity);

        Task UpdateAsync(T entity);

        Task SaveChangesAsync();
    }
}
