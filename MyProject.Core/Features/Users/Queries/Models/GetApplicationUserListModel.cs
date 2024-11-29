using MediatR;
using MyProject.Core.Features.Users.Result;
using MyProject.Core.Generic_Response;


namespace MyProject.Core.Features.Users.Queries.Models
{
    public class GetApplicationUserListModel : IRequest<Response<List<GetApplicationUserResponse>>>
    {

    }
}
