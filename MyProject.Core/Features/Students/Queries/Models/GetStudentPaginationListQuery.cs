using MediatR;
using MyProject.Core.Features.Students.Queries.Results;
using MyProject.Core.Wrapper;


namespace MyProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginationListQuery : IRequest<PaginationResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string[]? OrderBy { get; set; }
        public string Search { get; set; } = string.Empty;
    }
}
