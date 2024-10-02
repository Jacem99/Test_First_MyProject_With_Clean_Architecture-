using Microsoft.EntityFrameworkCore;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }      
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        
    }
}
