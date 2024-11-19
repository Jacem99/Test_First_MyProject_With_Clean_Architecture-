using MyProject.Core.Features.Students.Queries.Results;
using MyProject.Data.Entities;


namespace MyProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, ModelGetStudentMapping>().ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));
        }

    }
}
