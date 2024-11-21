using MediatR;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentModel: IRequest<Response<Student>>
    {
        public int Id { get; set; }
        public DeleteStudentModel(int id)
        {
            Id = id;
        }
    }
}
