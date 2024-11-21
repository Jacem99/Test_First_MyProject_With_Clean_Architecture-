using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.IRepository
{
    public interface  IDepartmentRepository : IGenericRepository<Department>
    {
        public Task<IEnumerable<Department>> GetListDepartment();
       // public Task<Department> GetDepartmentById(int id);
    }
}
