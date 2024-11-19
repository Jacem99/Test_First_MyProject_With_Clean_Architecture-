using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public GetStudentPaginatedListResponse(int studentId, string name, string adress, string departmentName)
        {
            StudentId = studentId;
            Name = name;
            Adress = adress;
            DepartmentName = departmentName;

        }
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? DepartmentName { get; set; }
    }
}
