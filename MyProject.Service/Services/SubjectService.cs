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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task DeleteSubjectById(Subjects subject)
        => await _subjectRepository.DeleteAsync(subject);
        

        public async Task<IEnumerable<Subjects>> GetListSubjects()
            => await _subjectRepository.GetByNoTracking().ToListAsync();
                                                          

        public async Task<Subjects> GetSubjectById(int id)
            => await _subjectRepository.GetByIdAsync(id);

    }
}
