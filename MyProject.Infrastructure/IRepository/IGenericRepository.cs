using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetByNoTracking();
        IQueryable<T> GetByTracking();

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);

        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> Entities);

        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollBack();
    }

}
