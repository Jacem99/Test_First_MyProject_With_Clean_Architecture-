using MediatR;
using MyProject.Core.Features.Subject.Queries.Results;
using MyProject.Core.Generic_Response;


namespace MyProject.Core.Features.Subject.Queries.Models
{
    public class GetListSubjectByIdModel : IRequest<Response<GetSubjectsResponse>>
    {
        public int Id { get; set; }
        public GetListSubjectByIdModel(int id)
        {
            Id = id;
        }
    }
}
