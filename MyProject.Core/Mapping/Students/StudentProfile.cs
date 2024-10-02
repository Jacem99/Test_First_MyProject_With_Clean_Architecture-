using AutoMapper;
using MyProject.Core.Features.Queries.Results;
using MyProject.Data.Entities;


namespace MyProject.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
        }
    }
}
