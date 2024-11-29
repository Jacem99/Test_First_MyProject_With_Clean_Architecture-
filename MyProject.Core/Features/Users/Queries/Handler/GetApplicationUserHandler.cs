using AutoMapper;
using MediatR;
using Microsoft.Identity.Client;
using MyProject.Core.Features.Users.Queries.Models;
using MyProject.Core.Features.Users.Result;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Users.Queries.Handler
{
    public class GetApplicationUserHandler :
        ResponseHandler,
        IRequestHandler<GetApplicationUserListModel, Response<List<GetApplicationUserResponse>>>,
        IRequestHandler<GetApplicationUserByIdModel, Response<GetApplicationUserResponse>>

    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _map;

        public GetApplicationUserHandler(IApplicationUserService applicationUserService, IMapper map)
        {
            _applicationUserService = applicationUserService;
            _map = map;
        }


        public async Task<Response<List<GetApplicationUserResponse>>> Handle(GetApplicationUserListModel request, CancellationToken cancellationToken)
        {
            // Get User List 
            List<ApplicationUser> UserList = await _applicationUserService.GetUserList();

            // Mapping 
           List<GetApplicationUserResponse> mapping =  _map.Map<List<GetApplicationUserResponse>>(UserList);
            
            // return User List 
            return Success(mapping);
        }

        public async Task<Response<GetApplicationUserResponse>> Handle(GetApplicationUserByIdModel request, CancellationToken cancellationToken)
        {

            // Check If User Exist 
            var checkUserExist = await _applicationUserService.GetUserById(request._userId);
            if (checkUserExist is null)
                    return NotFound<GetApplicationUserResponse>("User you want to find not found !!");
            // Mapping 
           var mapping = _map.Map<GetApplicationUserResponse>(checkUserExist);

            // Return 
            return Success(mapping);
        }
    }
}
