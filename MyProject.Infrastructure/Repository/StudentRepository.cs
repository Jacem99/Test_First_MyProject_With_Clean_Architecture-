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
    public class StudentRepository : GenericRepository<Student>,IStudentRepository 
    {
        private readonly DbSet<Student> _studentsRepository;

        public StudentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _studentsRepository = dbContext.Set<Student>();
        }

        public async Task DeleteStudentAsync(Student student)=>
            await DeleteAsync(student);
        public async Task<List<Student>> GetStudentsListAsync() => await _studentsRepository.Include(d => d.Department).ToListAsync();
        
    }
}
