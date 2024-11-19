

using AutoMapper;
using MediatR;
using MyProject.Core.Features.Departments.Queries.Models;
using MyProject.Core.Features.Departments.Queries.Results;
using MyProject.Core.Generic_Response;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Departments.Queries.Handlers
{
    public class GetListDepartmentHandler : ResponseHandler,
        IRequestHandler<GetListDepartmentModel, Response<List<GetListDepartmentResponse>>>
    {
        private readonly IMapper _mapper ;
        private readonly IDepartmentService _departmentService ;

        public GetListDepartmentHandler(IMapper mapper ,IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public async Task<Response<List<GetListDepartmentResponse>>> Handle(GetListDepartmentModel request, CancellationToken cancellationToken)
        {
            // Get List from service 
            var DepartmentsList =await _departmentService.GetDepartmentList();

            // Mapping 
            var mapList = _mapper.Map<List<GetListDepartmentResponse>>(DepartmentsList);

            // Return Result
            return Success(mapList);
        }
    }
}
