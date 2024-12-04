

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using MyProject.Core.Features.Departments.Queries.Models;
using MyProject.Core.Features.Departments.Queries.Results;
using MyProject.Core.Generic_Response;
using MyProject.Core.SharedResources;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Departments.Queries.Handlers
{
    public class GetListDepartmentHandler : ResponseHandler,
        IRequestHandler<GetListDepartmentModel, Response<List<GetListDepartmentResponse>>>,
        IRequestHandler<GetDepartmentIdModel, Response<GetDepartmentIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public GetListDepartmentHandler(IMapper mapper, IDepartmentService departmentService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _mapper = mapper;
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<List<GetListDepartmentResponse>>> Handle(GetListDepartmentModel request, CancellationToken cancellationToken)
        {
            // Get List from service 
            var DepartmentsList = await _departmentService.GetDepartmentList();

            // Mapping 
            var mapList = _mapper.Map<List<GetListDepartmentResponse>>(DepartmentsList);

            // Return Result
            return Success(mapList);
        }

        public async Task<Response<GetDepartmentIdResponse>> Handle(GetDepartmentIdModel request, CancellationToken cancellationToken)
        {
            // Get List From Service 
            var DepartmentById = await _departmentService.GetDepartmentById(request.Id);
            // Check If Exist 

            if (request.Id <= 0)
                return BadRequest<GetDepartmentIdResponse>(_stringLocalizer[SharedResourcesKeys.Empty]);
            if (DepartmentById == null)
                return NotFound<GetDepartmentIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            // Mapping 

            var map = _mapper.Map<GetDepartmentIdResponse>(DepartmentById);
            // Return Result 
            return Success(map);
        }
    }
}
