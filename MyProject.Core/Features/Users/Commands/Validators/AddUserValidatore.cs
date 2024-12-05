/*using FluentValidation;
using MyProject.Core.Features.Users.Commands.Models;

namespace MyProject.Core.Features.Users.Commands.Validators
{
    public class AddUserValidatore : AbstractValidator<AddApplicationUserCommand>

    {
        public AddUserValidatore()
        {
            ApplyUserRoles();
        }

        public void ApplyUserRoles()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email Is Requied");
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("PhoneNumber Is Requied");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Email Is Requied");
            RuleFor(u => u.ConfirmPassword).Equal(u => u.Password).WithMessage("Password and Confirm Not Equals");

            RuleFor(u => u.FullName).NotEmpty().WithMessage("Email Is Requied");
        }

    }
}
*/