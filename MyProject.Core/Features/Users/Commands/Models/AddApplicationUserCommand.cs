
using MediatR;
using MyProject.Core.Generic_Response;

namespace MyProject.Core.Features.Users.Commands.Models
{
    public class AddApplicationUserCommand : IRequest<Response<AddApplicationUserCommand>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
