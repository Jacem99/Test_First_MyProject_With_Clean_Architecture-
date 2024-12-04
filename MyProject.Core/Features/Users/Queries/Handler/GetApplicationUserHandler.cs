using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using MyProject.Core.Features.Users.Queries.Models;
using MyProject.Core.Features.Users.Result;
using MyProject.Core.Generic_Response;
using MyProject.Core.SharedResources;
using MyProject.Core.Wrapper;
using MyProject.Data.Entities;
using MyProject.Service.IServices;
using System.Linq.Expressions;

namespace MyProject.Core.Features.Users.Queries.Handler
{
    public class GetApplicationUserHandler :
        ResponseHandler,
        IRequestHandler<GetApplicationUserListModel, Response<List<GetApplicationUserResponse>>>,
        IRequestHandler<GetApplicationUserByIdModel, Response<GetApplicationUserResponse>>,
        IRequestHandler<GetApplicationUserByPagination, PaginationResult<GetApplicationUserPaginatedListResponse>>

    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IMapper _map;

        public GetApplicationUserHandler(IApplicationUserService applicationUserService, IMapper map, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _applicationUserService = applicationUserService;
            _map = map;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<Response<List<GetApplicationUserResponse>>> Handle(GetApplicationUserListModel request, CancellationToken cancellationToken)
        {
            // Get User List 
            List<ApplicationUser> UserList = await _applicationUserService.GetUserList();

            // Mapping 
            List<GetApplicationUserResponse> mapping = _map.Map<List<GetApplicationUserResponse>>(UserList);

            // return User List 
            return Success(mapping);
        }

        public async Task<Response<GetApplicationUserResponse>> Handle(GetApplicationUserByIdModel request, CancellationToken cancellationToken)
        {

            // Check If User Exist 
            var checkUserExist = await _applicationUserService.GetUserById(request._userId);
            if (checkUserExist is null)
                return NotFound<GetApplicationUserResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            // Mapping 
            var mapping = _map.Map<GetApplicationUserResponse>(checkUserExist);

            // Return 
            return Success(mapping);
        }

        public async Task<PaginationResult<GetApplicationUserPaginatedListResponse>> Handle(GetApplicationUserByPagination request, CancellationToken cancellationToken)
        {

            Expression<Func<ApplicationUser, GetApplicationUserPaginatedListResponse>> expression = e => new GetApplicationUserPaginatedListResponse(e.Id, e.FullName, e.UserName, e.Email, e.Country, e.Age, e.PhoneNumber);

            // Get List Pagination 
            IQueryable<ApplicationUser> userQueryable = _applicationUserService.FilterGetStudentPaginatedQueryable(request.Search);

            PaginationResult<GetApplicationUserPaginatedListResponse> userList = await userQueryable.Select(expression).ToPaginationListAsync(request.PageNumber, request.PageSize);

            // return Users
            return userList;
        }
    }
}
