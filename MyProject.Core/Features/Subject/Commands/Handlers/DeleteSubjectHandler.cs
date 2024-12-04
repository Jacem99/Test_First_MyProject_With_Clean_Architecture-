using MediatR;
using Microsoft.Extensions.Localization;
using MyProject.Core.Features.Subject.Commands.Models;
using MyProject.Core.Generic_Response;
using MyProject.Core.SharedResources;
using MyProject.Data.Entities;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Subject.Commands.Handlers
{
    public class DeleteSubjectHandler : ResponseHandler
            , IRequestHandler<DeleteSubjectModel, Response<Subjects>>
    {
        private readonly ISubjectService _subjectService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public DeleteSubjectHandler(ISubjectService subjectService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _subjectService = subjectService;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<Subjects>> Handle(DeleteSubjectModel request, CancellationToken cancellationToken)
        {
            // Chect Subject Model Exist 
            var checkSubjectExist = await _subjectService.GetSubjectById(request.Id);
            if (checkSubjectExist is null)
                return NotFound<Subjects>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            // Delete Model
            await _subjectService.DeleteSubjectById(checkSubjectExist);
            // Return Model
            return Success(checkSubjectExist, null, _stringLocalizer[SharedResourcesKeys.Deleted]);
        }
    }
}
