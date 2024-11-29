using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Features.Users.Commands.Models;
using MyProject.Core.Features.Users.Queries.Models;
using MyProject.Core.Features.Users.Result;
using MyProject.Core.Generic_Response;
using MyProject.Data.AppMetaData;

namespace MyProject.Api.Controllers
{

    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.User.List)]
        public async Task<Response<List<GetApplicationUserResponse>>> GetUserList()
            => await _mediator.Send(new GetApplicationUserListModel());

        [HttpGet(Router.User.GetById)]
        public async Task<Response<GetApplicationUserResponse>> GetUserById([FromRoute] string Id)
           => await _mediator.Send(new GetApplicationUserByIdModel(Id));

        [HttpPost(Router.User.Add)]
        public async Task<Response<AddApplicationUserCommand>> AddUser([FromBody] AddApplicationUserCommand user)
           => await _mediator.Send(user);

    }
}
