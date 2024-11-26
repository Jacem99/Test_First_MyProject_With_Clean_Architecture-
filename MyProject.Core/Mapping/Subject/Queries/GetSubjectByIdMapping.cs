using AutoMapper;
using MyProject.Core.Features.Subject.Queries.Results;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Mapping.Subject
{
    public partial class SubjectsProfile : Profile
    {
        public void GetSubjectByIdMapping()
        {
            CreateMap<Subjects, GetSubjectsResponse>();
        }
    }

}
