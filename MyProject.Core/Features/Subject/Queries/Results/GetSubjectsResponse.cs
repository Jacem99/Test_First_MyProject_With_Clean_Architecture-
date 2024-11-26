using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Features.Subject.Queries.Results
{
    public class GetSubjectsResponse
    {
        public int SubjectsId { get; set; }
        public string? SubjectName { get; set; }
        public int Period { get; set; }
    }
}
