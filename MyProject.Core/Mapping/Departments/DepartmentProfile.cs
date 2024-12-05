using AutoMapper;

namespace MyProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetListDepartmentModelMapping();
            GetDepartmentIdIdModelMapping();
        }
    }
}

