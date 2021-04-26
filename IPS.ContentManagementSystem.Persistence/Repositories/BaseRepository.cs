using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        public readonly IPSContentManagementDbContext _iPSContentManagementDbContext;

        public BaseRepository(IPSContentManagementDbContext iPSContentManagementDbContext)
        {
            _iPSContentManagementDbContext = iPSContentManagementDbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _iPSContentManagementDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _iPSContentManagementDbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _iPSContentManagementDbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _iPSContentManagementDbContext.Set<T>().AddAsync(entity);
            await _iPSContentManagementDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _iPSContentManagementDbContext.Entry(entity).State = EntityState.Modified;
            await _iPSContentManagementDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _iPSContentManagementDbContext.Set<T>().Remove(entity);
            await _iPSContentManagementDbContext.SaveChangesAsync();
        }
    }
}
