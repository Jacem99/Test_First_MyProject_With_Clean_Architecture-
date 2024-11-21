using Microsoft.EntityFrameworkCore;
using MyProject.Data.Entities;
using MyProject.Infrastructure.IRepository;
using MyProject.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Services
{
    public class DepartmentService : IDepartmentService 
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task DeleteDeaprtmentById(Department department)
            => await _departmentRepository.DeleteAsync(department);
        

        public async Task<Department> GetDepartmentById(int id)
        {
            var departById = await _departmentRepository.GetByNoTracking()
                .Where(d => d.DepartmentId.Equals(id))
                .Include(stud => stud.Students)
                .Include(dsub => dsub.DepartmentSubjects)
                .ThenInclude(sub => sub.Subjects).FirstOrDefaultAsync();
            return departById;
        }           

        public Task<IEnumerable<Department>> GetDepartmentList()
             => _departmentRepository.GetListDepartment();
    }
}
