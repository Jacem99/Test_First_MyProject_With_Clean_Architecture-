using AutoMapper;

using MyProject.Core.Features.Departments.Queries.Results;
using MyProject.Data.Entities;


namespace MyProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
      public void GetListDepartmentModelMapping()
        {
            CreateMap<Department, GetListDepartmentResponse>()
                .ForMember(dest => dest.DepartmentName, option => option.MapFrom(src => src.Name));
        }
    }
}
