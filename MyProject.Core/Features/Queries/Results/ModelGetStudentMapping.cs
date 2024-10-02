using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Queries.Results
{
    public class ModelGetStudentMapping
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? DepartmentName { get; set; }
    }
}
