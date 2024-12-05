using MediatR;
using MyProject.Core.Generic_Response;

namespace MyProject.Core.Features.Emails.Commands.Models
{
    public class SendEmailCommandModel : IRequest<Response<string>>
    {
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
