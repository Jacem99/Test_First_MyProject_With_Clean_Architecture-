using MyProject.Core.Features.Queries.Results;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
