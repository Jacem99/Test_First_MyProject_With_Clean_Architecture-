using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Mapping.Subject
{
    public partial class SubjectsProfile : Profile
    {
        public SubjectsProfile()
        {
            GetListSubjectsMapping();
            GetSubjectByIdMapping();
            
        }
    }
}
