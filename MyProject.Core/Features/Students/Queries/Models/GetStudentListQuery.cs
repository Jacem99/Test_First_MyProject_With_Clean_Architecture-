using MediatR;
using MyProject.Core.Features.Students.Queries.Results;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<ModelGetStudentListMapping>>>
    {
    }
}
