using MediatR;
using MyProject.Core.Features.Students.Queries.Results;
using MyProject.Core.Generic_Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Students.Queries.Models
{
    public class GetStudentQueryByID : IRequest<Response<ModelGetStudentMapping>>
    {
        public int StudentId { get; set; }
        public GetStudentQueryByID(int Id)
        {
            StudentId = Id;
        }
    }
}
