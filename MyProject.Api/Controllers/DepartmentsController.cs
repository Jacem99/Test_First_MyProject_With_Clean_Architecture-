using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Features.Departments.Commands.Models;
using MyProject.Core.Features.Departments.Queries.Models;
using MyProject.Core.Features.Students.Queries.Models;
using MyProject.Data.AppMetaData;

namespace MyProject.Api.Controllers
{

    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetDepartments()
            => Ok(await _mediator.Send(new GetListDepartmentModel()));

        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int Id)
           => Ok(await _mediator.Send(new GetDepartmentIdModel(Id)));

        [HttpDelete(Router.DepartmentRouting.DeletById)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int Id)
          => Ok(await _mediator.Send(new DeleteDepartmentModel(Id)));

    }
}
