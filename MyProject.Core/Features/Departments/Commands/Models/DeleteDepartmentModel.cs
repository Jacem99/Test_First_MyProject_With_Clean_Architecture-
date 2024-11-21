using MediatR;
using MyProject.Core.Generic_Response;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentModel : IRequest<Response<Department>>
    {
        public readonly int Id;
        public DeleteDepartmentModel(int id)
        {
           Id = id;
        }
    }
}
