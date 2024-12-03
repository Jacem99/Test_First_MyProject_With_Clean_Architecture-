using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Features.Authentication.Commands.Models;
using MyProject.Data.AppMetaData;

namespace MyProject.Api.Controllers
{

    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public AuthenticationController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn(SignInCommand signInCommand)
        {
            return Ok(await _mediatR.Send(signInCommand));
        }

    }
}
