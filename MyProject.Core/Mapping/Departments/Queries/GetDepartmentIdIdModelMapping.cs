using AutoMapper;
using MyProject.Core.Features.Departments.Queries.Results;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        
        public void GetDepartmentIdIdModelMapping() {
            CreateMap<Department, GetDepartmentIdResponse>()
                .ForMember(dest => dest.DepartmentName, option => option.MapFrom(src => src.Name))
                .ForMember(dest => dest.StudentsList, option => option.MapFrom(src => src.Students))
                .ForMember(dest => dest.SubjectsList, option => option.MapFrom(src => src.DepartmentSubjects));

            CreateMap<DepartmentSubject, SubjectsResponse>()
                .ForMember(dest => dest.Id, option => option.MapFrom(src => src.SubjectsId))
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Subjects.SubjectName));

            CreateMap<Student, StudentsResponse>()
                .ForMember(dest => dest.Id, option => option.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Name));


        }
    }
}
