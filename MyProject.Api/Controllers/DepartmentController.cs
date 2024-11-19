using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Features.Departments.Queries.Models;
using MyProject.Data.AppMetaData;

namespace MyProject.Api.Controllers
{
   
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetDepartments()
            => Ok(await _mediator.Send(new GetListDepartmentModel()));
        
    }
}
