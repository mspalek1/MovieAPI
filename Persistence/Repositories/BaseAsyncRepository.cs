using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Persistence.Repositories
{
    public class BaseAsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieDBContext _dbContext;
        public BaseAsyncRepository(MovieDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            if (result is null)
            {
                throw new NotFoundException($"The object {typeof(T)} with the identifier {id} was not found");
            }
           
            return result;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
