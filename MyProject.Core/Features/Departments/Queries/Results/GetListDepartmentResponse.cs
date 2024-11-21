using MediatR;
using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Departments.Queries.Results
{
    public class GetListDepartmentResponse
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
      
    }
}
