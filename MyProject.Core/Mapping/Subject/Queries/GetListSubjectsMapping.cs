using AutoMapper;

using MyProject.Core.Features.Subject.Queries.Results;
using MyProject.Data.Entities;

namespace MyProject.Core.Mapping.Subject
{
    public partial class SubjectsProfile : Profile
    {
        public void GetListSubjectsMapping()
        {
            CreateMap<Subjects, GetSubjectsResponse>();
        }
    }
}
