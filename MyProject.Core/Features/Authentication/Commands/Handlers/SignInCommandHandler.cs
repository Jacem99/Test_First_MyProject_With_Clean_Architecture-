using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Core.Features.Authentication.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Authentication.Commands.Handlers
{
    public class SignInCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<string>>
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationUserService _authenticationUserService;
        public SignInCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthenticationUserService authenticationUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationUserService = authenticationUserService;
        }
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            // Check user is exist 
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user is null) return BadRequest<string>("Invalid SingIn");

            // Try To Sign In 
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded)
                return BadRequest<string>("Invalid SingIn");

            var resultToken = await _authenticationUserService.GetJwtToken(user);

            return Success(resultToken);

        }
    }
}
