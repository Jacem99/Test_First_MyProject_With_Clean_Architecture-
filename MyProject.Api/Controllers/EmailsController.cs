using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Features.Emails.Commands.Models;
using MyProject.Data.AppMetaData;

namespace MyProject.Api.Controllers
{

    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Router.Email.Send)]
        public async Task<IActionResult> SendingEmail([FromBody] SendEmailCommandModel query)
        => Ok(await _mediator.Send(query));
    }
}
