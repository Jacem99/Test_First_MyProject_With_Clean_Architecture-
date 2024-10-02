using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Entities
{
    public class DepartmentSubject
    {
        [Key] public int DepartmentSubjectId { get; set; }

        public int DepartmentId { get; set; }
        public int SubjectsId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("SubjectsId")]
        public virtual Subjects Subjects { get; set; }


    }
}