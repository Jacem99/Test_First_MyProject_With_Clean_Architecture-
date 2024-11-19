using AutoMapper;
using MyProject.Core.Features.Departments.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile() {
            GetListDepartmentModelMapping();
        }
    }
}
