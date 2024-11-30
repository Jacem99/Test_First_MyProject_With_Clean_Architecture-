using Azure;
using MediatR;

namespace MyProject.Core.Features.Users.Commands.Models
{
    public class UpdateApplicationUserCommand : IRequest<Response<UpdateApplicationUserCommand>>
    {
        public string Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
