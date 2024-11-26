using MediatR;

using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Features.Subject.Commands.Models;
using MyProject.Core.Features.Subject.Queries.Models;
using MyProject.Core.Features.Subject.Queries.Results;
using MyProject.Core.Generic_Response;
using MyProject.Data.AppMetaData;
using MyProject.Data.Entities;

namespace MyProject.Api.Controllers
{
    
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.SubjectRouting.List)]
        public async Task<Response<List<GetSubjectsResponse>>> GetSubjectList() {
            return await _mediator.Send(new GetListSubjectsModel());
        }

        [HttpGet(Router.SubjectRouting.GetById)]
        public async Task<Response<GetSubjectsResponse>> GetSubjectById(int Id)
        {
            return await _mediator.Send(new GetListSubjectByIdModel(Id));
        }
        [HttpDelete(Router.SubjectRouting.DeletById)]
        public async Task<Response<Subjects>> DeleteSubjectById(int Id)
        {
            return await _mediator.Send(new DeleteSubjectModel(Id));
        }
    }
}
