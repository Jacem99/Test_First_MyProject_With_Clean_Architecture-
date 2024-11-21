using MediatR;
using MyProject.Core.Features.Departments.Queries.Results;
using MyProject.Core.Generic_Response;


namespace MyProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentIdModel : IRequest<Response<GetDepartmentIdResponse>>
    {
        public GetDepartmentIdModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
