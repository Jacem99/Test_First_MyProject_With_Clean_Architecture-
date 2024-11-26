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
    public class SubjectRepository : GenericRepository<Subjects>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
