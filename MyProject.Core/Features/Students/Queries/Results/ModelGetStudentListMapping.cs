using MyProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Students.Queries.Results
{
    public class ModelGetStudentListMapping
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? DepartmentName { get; set; }
    }
}
