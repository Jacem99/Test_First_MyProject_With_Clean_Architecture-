﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Features.Queries.Models;
using MyProject.Data.AppMetaData;

namespace MyProject.Api.Controllers
{
   
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()=> Ok(await _mediator.Send(new GetStudentListQuery()));

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int Id) => 
            Ok(await _mediator.Send(new GetStudentQueryByID(Id)));

    }

}
