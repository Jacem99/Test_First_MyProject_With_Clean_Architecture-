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
    public class StudentServiece : IStudentServiece
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServiece(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> GetStudentByIdAsync(int Id) =>
            _studentRepository.GetByNoTracking()
                .Include(d => d.Department).Where(s => s.StudentId.Equals(Id))
                .FirstOrDefault();

       public Task<List<Student>> GetStudentsListAsync()=> _studentRepository.GetStudentsListAsync();

        public IQueryable<Student> GetStudentQueryable() => _studentRepository.GetByNoTracking().Include(d => d.Department).AsQueryable();

        public IQueryable<Student> FilterGetStudentPaginatedQueryable(string search)
        {
          var queryable = _studentRepository.GetByNoTracking().Include(d => d.Department).AsQueryable();

           return queryable.Where(q => q.Name.Contains(search)|| q.Adress.Contains(search));
        }


        public async Task DeleteStudent(Student student) => 
            await _studentRepository.DeleteAsync(student);
        
    }
}
