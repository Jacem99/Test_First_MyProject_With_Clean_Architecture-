using MediatR;
using MyProject.Core.Features.Students.Commands.Models;
using MyProject.Core.Features.Subject.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Subject.Commands.Handlers
{
    public class DeleteSubjectHandler : ResponseHandler
            , IRequestHandler<DeleteSubjectModel, Response<Subjects>>
    {
        private readonly ISubjectService _subjectService;

        public DeleteSubjectHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public async Task<Response<Subjects>> Handle(DeleteSubjectModel request, CancellationToken cancellationToken)
        {
            // Chect Subject Model Exist 
          var checkSubjectExist = await _subjectService.GetSubjectById(request.Id);
            if (checkSubjectExist is null)
                return NotFound<Subjects>("The Subject you want to delete not found !!");
            // Delete Model
            await  _subjectService.DeleteSubjectById(checkSubjectExist);
            // Return Model
            return Success(checkSubjectExist, null, "Successfull Delete");
        }
    }
}
