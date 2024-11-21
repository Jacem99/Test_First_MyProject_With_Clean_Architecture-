using MediatR;
using MyProject.Core.Features.Students.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using MyProject.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Students.Commands.Handlers
{
    public class DeleteStudentHandler : 
        ResponseHandler,
        IRequestHandler<DeleteStudentModel, Response<Student>>
    {
        private readonly IStudentServiece _studentServiece;

        public DeleteStudentHandler(IStudentServiece studentServiece)
        {
            _studentServiece = studentServiece;
        }

        public async Task<Response<Student>> Handle(DeleteStudentModel request, CancellationToken cancellationToken)
        {
            // Check Student Model Exist
            var resultStudent = await _studentServiece.GetStudentByIdAsync(request.Id);
            if (resultStudent is null)
                return NotFound<Student>("Student that you want to delete not found !!");
            // Delete Model 
            await _studentServiece.DeleteStudent(resultStudent);
            return Success(resultStudent,null,"Successfull Deleted");
        }
    }
}
