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

        public Task<ICollection<Department>> GetDepartmentList()
             => _departmentRepository.GetListDepartment();
    }
}
