using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Core.Features.Users.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using MyProject.Service.IServices;
using System.Text;

namespace MyProject.Core.Features.Users.Commands.Handler
{
    public class AddApplicationUserHandler : ResponseHandler
        , IRequestHandler<AddApplicationUserCommand, Response<AddApplicationUserCommand>>
    {
        private IApplicationUserService _applicationUserService;
        private IMapper _map;
        private UserManager<ApplicationUser> _userManager;
        public AddApplicationUserHandler(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, IMapper map)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _map = map;
        }
        public async Task<Response<AddApplicationUserCommand>> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {
            // Check Email Exist 
            if (await _applicationUserService.IsExistEmail(request.Email))
                return BadRequest<AddApplicationUserCommand>("Email Exist!!");

            //Check Phone Exist 
            if (await _applicationUserService.IsExistPhone(request.PhoneNumber))
                return BadRequest<AddApplicationUserCommand>("Phone Exist!!");
            // map 
            var identityUserMap = _map.Map<ApplicationUser>(request);
            // Add User
            var addUser = await _userManager.CreateAsync(identityUserMap, request.Password);
            StringBuilder resultError = new StringBuilder();
            foreach (var reuslt in addUser.Errors)
                resultError.Append(reuslt.Description);
            if (!addUser.Succeeded)
                return BadRequest<AddApplicationUserCommand>(resultError.ToString());
            // return Result 
            return Success<AddApplicationUserCommand>(request, null, "Sccessfully Add User ");
        }
    }
}
