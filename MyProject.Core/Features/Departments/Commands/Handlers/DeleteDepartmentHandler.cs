using MediatR;
using Microsoft.Extensions.Localization;
using MyProject.Core.Features.Departments.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Core.SharedResources;
using MyProject.Data.Entities;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Departments.Commands.Handlers
{
    public class DeleteDepartmentHandler :
        ResponseHandler,
        IRequestHandler<DeleteDepartmentModel, Response<Department>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public DeleteDepartmentHandler(IDepartmentService departmentService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
        }
        public async Task<Response<Department>> Handle(DeleteDepartmentModel request, CancellationToken cancellationToken)
        {
            // Check Department Model Exist 
            var resultCheckDepartment = await _departmentService.GetDepartmentById(request.Id);
            if (resultCheckDepartment is null)
                return NotFound<Department>();
            // Delete Model
            await _departmentService.DeleteDeaprtmentById(resultCheckDepartment);
            // Return Model 
            return Success(resultCheckDepartment, null, _stringLocalizer[SharedResourcesKeys.Deleted]);

        }
    }
}
