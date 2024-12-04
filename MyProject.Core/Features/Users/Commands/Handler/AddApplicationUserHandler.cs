using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using MyProject.Core.Features.Users.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Core.SharedResources;
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
        private IStringLocalizer<SharedResource> _stringLocalizer;
        public AddApplicationUserHandler(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, IMapper map, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _map = map;
            _stringLocalizer = stringLocalizer;
        }
        public async Task<Response<AddApplicationUserCommand>> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {
            // Check Email Exist 
            if (await _applicationUserService.IsExistEmail(request.Email))
                return BadRequest<AddApplicationUserCommand>(_stringLocalizer[SharedResourcesKeys.EmailExist]);

            //Check Phone Exist 
            if (await _applicationUserService.IsExistPhone(request.PhoneNumber))
                return BadRequest<AddApplicationUserCommand>(_stringLocalizer[SharedResourcesKeys.PhoneExist]);
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
            return Success<AddApplicationUserCommand>(request, null, _stringLocalizer[SharedResourcesKeys.Created]);
        }
    }
}
