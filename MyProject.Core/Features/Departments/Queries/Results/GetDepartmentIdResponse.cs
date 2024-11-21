using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Departments.Queries.Results
{
    public class GetDepartmentIdResponse
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public  List<StudentsResponse>? StudentsList { get; set; }
        public  List<SubjectsResponse>? SubjectsList { get; set; }
    }


    public class StudentsResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class SubjectsResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
