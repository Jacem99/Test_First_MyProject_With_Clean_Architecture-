using MediatR;
using MyProject.Core.Features.Users.Result;
using MyProject.Core.Wrapper;

namespace MyProject.Core.Features.Users.Queries.Models
{
    public class GetApplicationUserByPagination : IRequest<PaginationResult<GetApplicationUserPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string[]? OrderBy { get; set; }
        public string Search { get; set; } = string.Empty;
    }
}
