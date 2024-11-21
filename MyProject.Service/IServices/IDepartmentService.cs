using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.IServices
{
    public interface IDepartmentService
    {
     Task<ICollection<Department>> GetDepartmentList();
     Task<Department> GetDepartmentById(int id);
        Task DeleteDeaprtmentById(Department department);
    }
}
