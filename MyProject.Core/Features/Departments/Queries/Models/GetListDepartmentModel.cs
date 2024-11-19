using MediatR;
using MyProject.Core.Features.Departments.Queries.Results;
using MyProject.Core.Generic_Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Departments.Queries.Models
{
    public class GetListDepartmentModel : IRequest<Response<List<GetListDepartmentResponse>>>
    {
    }
}
