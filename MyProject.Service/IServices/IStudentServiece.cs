using MyProject.Data.Entities;
using MyProject.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.IServices
{
    public interface IStudentServiece 
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int Id);
        public IQueryable<Student> GetStudentQueryable();
        public IQueryable<Student> FilterGetStudentPaginatedQueryable(string search);
        public Task DeleteStudent(Student student);
    }
}
 