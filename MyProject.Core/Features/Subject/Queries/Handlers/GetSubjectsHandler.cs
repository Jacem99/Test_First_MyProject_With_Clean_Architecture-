using AutoMapper;
using MediatR;
using MyProject.Core.Features.Subject.Queries.Results;
using MyProject.Core.Features.Subject.Queries.Models;
using MyProject.Core.Generic_Response;
using MyProject.Service.IServices;

namespace MyProject.Core.Features.Subject.Queries.Handlers
{
    public class GetSubjectsHandler :
        ResponseHandler,
        IRequestHandler<GetListSubjectByIdModel, Response<GetSubjectsResponse>>,
        IRequestHandler<GetListSubjectsModel, Response<List<GetSubjectsResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;
        public GetSubjectsHandler(IMapper mapper, ISubjectService subjectService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
        }
        public async Task<Response<List<GetSubjectsResponse>>> Handle(GetListSubjectsModel request, CancellationToken cancellationToken)
        {
            // Get List OF Subjects 
           var subjectsList = await _subjectService.GetListSubjects();
            // Mapping Models
           var map = _mapper.Map<List<GetSubjectsResponse>>(subjectsList);

            // Return Models
            return Success(map);
        }

        public async Task<Response<GetSubjectsResponse>> Handle(GetListSubjectByIdModel request, CancellationToken cancellationToken)
        {
            // Check Subject Model Exist
            var subjectModel =await _subjectService.GetSubjectById(request.Id);
            // Mapping Models
          var map =  _mapper.Map<GetSubjectsResponse>(subjectModel);
            // Return Model
            return Success(map);
        }
    }
}
