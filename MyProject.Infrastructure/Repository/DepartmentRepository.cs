using Microsoft.EntityFrameworkCore;
using MyProject.Data.Entities;
using MyProject.Infrastructure.Data;
using MyProject.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        private readonly DbSet<Department> _departmentsRepository;

        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _departmentsRepository = dbContext.Set<Department>();
        }
        public async Task<ICollection<Department>> GetListDepartment()
            => await _departmentsRepository.ToListAsync();
        
    }
}
