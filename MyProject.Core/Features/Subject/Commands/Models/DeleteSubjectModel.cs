using MediatR;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Subject.Commands.Models
{
    public class DeleteSubjectModel : IRequest<Response<Subjects>>
    {
        public readonly int Id;
        public DeleteSubjectModel(int id ) { 
        Id = id;
        }
    }
}
