using MediatR;
using MyProject.Core.Features.Subject.Queries.Results;
using MyProject.Core.Generic_Response;


namespace MyProject.Core.Features.Subject.Queries.Models
{
    public class GetListSubjectsModel : IRequest<Response<List<GetSubjectsResponse>>>
    {
    }
}
