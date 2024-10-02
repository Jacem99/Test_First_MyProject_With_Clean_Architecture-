using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyProject.Infrastructure.Data;
using MyProject.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public IQueryable<T> GetByTracking() => _dbContext.Set<T>().AsQueryable();
        public IQueryable<T> GetByNoTracking() => _dbContext.Set<T>().AsNoTracking().AsQueryable();

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }


        public IDbContextTransaction BeginTransaction() => _dbContext.Database.BeginTransaction();
        public void CommitTransaction() => _dbContext.Database.CommitTransaction();
        public void RollBack() => _dbContext.Database.RollbackTransaction();

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

        }
        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();


    }
}
