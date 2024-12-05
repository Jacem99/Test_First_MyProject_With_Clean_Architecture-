using MediatR;
using Microsoft.Extensions.Localization;
using MyProject.Core.Features.Emails.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Core.SharedResources;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Emails.Commands.Handler
{
    public class SendEmailCommandHandler :
       ResponseHandler, IRequestHandler<SendEmailCommandModel, Response<string>>
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IEmailService _emailService;

        public SendEmailCommandHandler(IStringLocalizer<SharedResource> stringLocalizer, IEmailService emailService)
        {
            _stringLocalizer = stringLocalizer;
            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(SendEmailCommandModel request, CancellationToken cancellationToken)
        {
            if (await _emailService.SendEmailAsync(request.Email, request.Message) == "Success")
                return Success<string>(_stringLocalizer[SharedResourcesKeys.EmailSendSuccessfully]);

            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailSendFaild]);
            throw new NotImplementedException();
        }
    }
}
