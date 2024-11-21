using MediatR;
using MyProject.Core.Features.Departments.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using MyProject.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Departments.Commands.Handlers
{
    public class DeleteDepartmentHandler : 
        ResponseHandler,
        IRequestHandler<DeleteDepartmentModel, Response<Department>>
    {
        private readonly IDepartmentService _departmentService;
        public DeleteDepartmentHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<Response<Department>> Handle(DeleteDepartmentModel request, CancellationToken cancellationToken)
        {
            // Check Department Model Exist 
            var resultCheckDepartment = await _departmentService.GetDepartmentById(request.Id);
            if (resultCheckDepartment is null)
                return NotFound<Department>("Department you want to delete not found !!");
            // Delete Model
              await  _departmentService.DeleteDeaprtmentById(resultCheckDepartment);
            // Return Model 
            return Success(resultCheckDepartment , null , "Successfull Deleted");

        }
    }
}
