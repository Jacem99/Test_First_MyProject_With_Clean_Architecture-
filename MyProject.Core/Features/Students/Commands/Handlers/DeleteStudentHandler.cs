using MediatR;
using Microsoft.Extensions.Localization;
using MyProject.Core.Features.Students.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Core.SharedResources;
using MyProject.Data.Entities;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Students.Commands.Handlers
{
    public class DeleteStudentHandler :
        ResponseHandler,
        IRequestHandler<DeleteStudentModel, Response<Student>>
    {
        private readonly IStudentServiece _studentServiece;

        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public DeleteStudentHandler(IStudentServiece studentServiece, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _studentServiece = studentServiece;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<Student>> Handle(DeleteStudentModel request, CancellationToken cancellationToken)
        {
            // Check Student Model Exist
            var resultStudent = await _studentServiece.GetStudentByIdAsync(request.Id);
            if (resultStudent is null)
                return NotFound<Student>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            // Delete Model 
            await _studentServiece.DeleteStudent(resultStudent);
            return Success(resultStudent, null, _stringLocalizer[SharedResourcesKeys.Deleted]);
        }
    }
}
